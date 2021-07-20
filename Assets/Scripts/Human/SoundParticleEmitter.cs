using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human
{
    public class SoundParticleEmitter : MonoBehaviour
    {
        public ParticleSystem particles;

        private float currentVolume = 0;

        void Start()
        {
            StartCoroutine(SoundWave());
        } 

        void OnAudioFilterRead(float[] samples, int channels)
        {
            float volume = 0;
            foreach (var sample in samples)
                volume += Mathf.Abs(sample);

            currentVolume = volume / samples.Length;
        }

        IEnumerator SoundWave()
        {
            while (isActiveAndEnabled)
            {
                Emit();
                yield return new WaitForSeconds(0.25f);
            }
        }

        void Emit()
        {
            var circle = Mathf.PI * 2;
            var count = currentVolume > 0.01f ? 1 : 0;
            var lifetime = currentVolume * 50;

            for (float i = 0; i < circle; i += circle / 50)
            {
                particles.Emit(new ParticleSystem.EmitParams() {
                    startLifetime = lifetime,
                    velocity = new Vector2(
                        Mathf.Cos(i),
                        Mathf.Sin(i)
                    ) * lifetime,
                }, count);
            }
        }
    }
}
