using System.Collections;

using UnityEngine;
using Photon.Pun;

namespace Audio
{
    public class Sound : MonoBehaviourPun, IPunInstantiateMagicCallback
    {
        [SerializeField] private LayerMask walls;

        public Scriptable settings;
        public GameObject follow;
        public GameObject listener;

        private AudioSource source;
        private AudioLowPassFilter filter;
        private ParticleSystem particles = null;

        private float[] datas = new float[512];
        private bool isAlien;

        private float particleMultiplier;
        private float speedMultiplier;
        private float volume;
        private int floorLevel;

        private float FilterTarget
        {
            get => Physics2D.Linecast(
                transform.position,
                listener.transform.position,
                walls
            ).collider == null
                ? 22000
                : 2000;
        }

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            filter = GetComponent<AudioLowPassFilter>();
            particles = GetComponentInChildren<ParticleSystem>();

            listener = Player.Manager.Player;
            isAlien = Player.Manager.MyRole == Player.RoleID.Alien;
        }

        private void Update()
        {
            if (follow)
                transform.position = follow.transform.position;

            if (!source.isPlaying && !particles.IsAlive())
                Destroy(gameObject);

            if (listener != null && settings != null)
                ResolveSpatial();
        }

        private void ResolveSpatial()
        {
            float maxDistance = settings.maxDistance * volume;
            float distance = Vector2.Distance(transform.position, listener.transform.position);
            float distPercent = Mathf.Clamp01(1 - distance / maxDistance);
            float horizontalDiff = transform.position.x - listener.transform.position.x;

            horizontalDiff = Mathf.Clamp(horizontalDiff / maxDistance, -1, 1);

            source.volume = distPercent;
            source.panStereo = horizontalDiff;

            if (Player.Manager.CurrentFloor == floorLevel)
                filter.cutoffFrequency += (int)((FilterTarget - filter.cutoffFrequency) * 0.2);
        }

        private IEnumerator SoundWave()
        {
            // Debug.Log("Sound Wave INIT");
            while (source.isPlaying)
            {
                // Debug.Log("Sound is playing");
                if (GetVolume() >= settings.sensivity) Emit();
                yield return new WaitForSeconds(0.25f);
            }
        }

        private void Emit()
        {
            var circle = Mathf.PI * 2;
            for (float i = 0; i < circle; i += circle / 100)
                particles.Emit(new ParticleSystem.EmitParams()
                {
                    startLifetime = settings.alienDistance * volume,
                    velocity = new Vector2()
                    {
                        x = Mathf.Cos(i),
                        y = Mathf.Sin(i),
                    } * speedMultiplier,
                }, 1);
        }

        private float GetVolume()
        {
            float volume = 0.0f;
            source.GetSpectrumData(datas, 0, FFTWindow.Blackman);
            foreach (var data in datas)
                volume += data;

            return volume;
        }

        private void Initialize(int soundIndex)
        {
            source.clip = settings.clips[soundIndex];
            source.loop = settings.loop;

            var col = this.particles.collision;
            col.collidesWith = settings.collisionMask;

            var sameFloor = Player.Manager.CurrentFloor == floorLevel;

            if (!sameFloor)
            {
                var floorDiff = floorLevel - Player.Manager.CurrentFloor;
                filter.cutoffFrequency = 900 / Mathf.Abs(floorDiff);
            }

            source.Play();

            if (sameFloor && Player.Manager.MyRole == Player.RoleID.Alien) StartCoroutine(SoundWave());
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            var datas = info.photonView.InstantiationData;

            var soundID = (ID)datas[0];
            var viewId = (int)datas[3];
            var soundIndex = (int)datas[6];

            volume = Mathf.Clamp01((float)datas[2]);
            particleMultiplier = (float)datas[4];
            speedMultiplier = (float)datas[5];
            floorLevel = (int)datas[1];
            settings = Scriptable.GetById(soundID);

            filter.cutoffFrequency = FilterTarget;

            Initialize(soundIndex);

            if (viewId == -1) return;

            follow = Network.Manager.instance.GetView(viewId).gameObject;
        }

#if (UNITY_EDITOR)
        private void OnDrawGizmos()
        {
            if (!settings) return;
            var maxDistance = settings.maxDistance * volume;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, maxDistance);

            var dist = Vector2.Distance(transform.position, listener.transform.position);
            var hit = Physics2D.Linecast(listener.transform.position, transform.position, walls);
            var target = transform.position;

            Gizmos.color = Color.green;
            if (hit.collider != null)
            {
                Gizmos.color = Color.red;
                target = hit.point;
            }

            if (dist > maxDistance) Gizmos.color = Color.grey;

            Gizmos.DrawLine(listener.transform.position, target);
        }
#endif
    }
}