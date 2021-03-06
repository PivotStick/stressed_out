using System.Collections;

using UnityEngine;
using Photon.Pun;

namespace Audio
{
    public class Sound : MonoBehaviourPun, IPunInstantiateMagicCallback
    {
        public Scriptable settings;
        public GameObject follow;
        public GameObject Listener { get => Player.Main.local; }

        private AudioSource source;
        private AudioLowPassFilter filter;
        private ParticleSystem particles = null;

        private float[] datas = new float[512];

        public float particleMultiplier = 1;
        public float speedMultiplier = 1;
        public float volume = 1;
        public int floorLevel = 0;

        private float FilterTarget
        {
            get => Listener ? Physics2D.Linecast(
                transform.position,
                Listener.transform.position,
                settings.soundCollision
            ).collider == null
                ? 22000
                : 2000 : 0;
        }

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            filter = GetComponent<AudioLowPassFilter>();
            particles = GetComponentInChildren<ParticleSystem>();
        }

        private void Update()
        {
            if (follow)
                transform.position = follow.transform.position;

            if (!source.isPlaying && !particles.IsAlive())
                Destroy(gameObject);

            if (Listener && settings)
                ResolveSpatial();
        }

        private void ResolveSpatial()
        {
            float maxDistance = settings.maxDistance * volume;
            float distance = Vector2.Distance(transform.position, Listener.transform.position);
            float distPercent = Mathf.Clamp01(1 - distance / maxDistance);
            float horizontalDiff = transform.position.x - Listener.transform.position.x;

            horizontalDiff = Mathf.Clamp(horizontalDiff / maxDistance, -1, 1);

            source.volume = distPercent;
            source.panStereo = horizontalDiff;

            if (Player.Manager.CurrentFloor == floorLevel)
                filter.cutoffFrequency += (int)((FilterTarget - filter.cutoffFrequency) * 0.2);
        }

        private IEnumerator SoundWave()
        {
            while (source.isPlaying)
            {
                if (GetVolume() >= settings.sensivity) Emit();
                yield return new WaitForSeconds(0.25f);
            }
        }

        private void Log(object message)
        {
            if (settings.id == ID.OpenDoor || settings.id == ID.CloseDoor)
                Debug.Log(message);
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

        public void Initialize(int soundIndex)
        {
            source.clip = settings.clips[soundIndex];
            source.loop = settings.loop;

            var col = this.particles.collision;
            col.collidesWith = settings.particleCollision;

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
            var viewId = (int)datas[2];
            var soundIndex = (int)datas[5];

            volume = Mathf.Clamp01((float)datas[1]);
            particleMultiplier = (float)datas[3];
            speedMultiplier = (float)datas[4];
            floorLevel = (int)datas[6];
            settings = Scriptable.GetById(soundID);

            filter.cutoffFrequency = FilterTarget;

            Initialize(soundIndex);

            if (viewId == -1) return;

            follow = Network.Manager.instance.GetView(viewId)?.gameObject;
        }

#if (UNITY_EDITOR)
        private void OnDrawGizmos()
        {
            if (!settings) return;
            var maxDistance = settings.maxDistance * volume;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, maxDistance);

            var dist = Vector2.Distance(transform.position, Listener.transform.position);
            var hit = Physics2D.Linecast(Listener.transform.position, transform.position, settings.soundCollision);
            var target = transform.position;

            Gizmos.color = Color.green;
            if (hit.collider != null)
            {
                Gizmos.color = Color.red;
                target = hit.point;
            }

            if (dist > maxDistance) Gizmos.color = Color.grey;

            Gizmos.DrawLine(Listener.transform.position, target);
        }
#endif
    }
}