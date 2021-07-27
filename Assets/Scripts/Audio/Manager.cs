using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Audio
{
    public class Manager : MonoBehaviour
    {
        public static Manager instance = null;

        [SerializeField] private Sound soundPrefab;
        [SerializeField] private AudioSource bgSource;
        [SerializeField] private Scriptable[] sounds;

        public Sound PlayLocalAt(
            Vector2 position,
            ID soundID
        ) {
            var sound = Instantiate(soundPrefab, position, Quaternion.identity);
            sound.settings = Scriptable.GetById(soundID);
            sound.Initialize(sound.settings.RandomIndex);

            return sound;
        }

        public void PlaySoundAt(
            Vector2 position,
            ID soundID,
            int floorLevel,
            float volume = 1f,
            int viewId = -1,
            float particleMultiplier = 1,
            float speedMultiplier = 1
        )
        {
            var soundIndex = Random.Range(0, Scriptable.GetById(soundID).clips.Length);
            var datas = new object[] {
                soundID,
                volume,
                viewId,
                particleMultiplier,
                speedMultiplier,
                soundIndex,
                floorLevel,
            };

            PhotonNetwork.Instantiate(
                soundPrefab.name,
                new Vector3 {
                    x = position.x,
                    y = position.y,
                    z = 0
                },
                Quaternion.identity,

                data: datas
            );
        }

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                DontDestroyOnLoad(bgSource.gameObject);
            } else {
                Destroy(gameObject);
                Destroy(bgSource.gameObject);
            }

            Scriptable.sounds = sounds;
        }

        public void FadeOutBG(float time = 3)
        {
            SetBGVolumeTo(0, time);
        }

        public void FadeInBG(float time = 3)
        {
            SetBGVolumeTo(1, time);
        }

        public void SetBGVolumeTo(float volume, float time)
        {
            StartCoroutine(FadeBG(volume, time));
        }

        private IEnumerator FadeBG(float volumeTarget, float time)
        {
            volumeTarget = Mathf.Clamp01(volumeTarget);
            float t = 0;
            float startVolume = bgSource.volume;

            while (bgSource.volume != volumeTarget)
            {
                t += Time.deltaTime;
                bgSource.volume = Mathf.Lerp(startVolume, volumeTarget, Mathf.Clamp01(t / time));
                yield return new WaitForEndOfFrame();
            }
        }
    }
}