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
            var shape = particles.shape;
            shape.radius = 0.5f;
        } 

        void OnEnable() => StartCoroutine(SoundWave());
        void OnDisable() => StopCoroutine(SoundWave());

        void OnAudioFilterRead(float[] samples, int channels)
        {
            float volume = 0;
            foreach (var sample in samples)
                volume += Mathf.Abs(sample);

            currentVolume = volume / samples.Length;
        }

        IEnumerator SoundWave()
        {
            while (true)
            {
                if (particles) Emit();
                yield return new WaitForSeconds(0.05f);
            }
        }

        void Emit()
        {
            var circle = Mathf.PI * 2;
            var count = currentVolume > 0.01f ? 1 : 0;
            var lifetime = currentVolume * 10;
            var speed = currentVolume * 20;

            for (float i = 0; i < circle; i += circle / 50)
            {
                particles.Emit(new ParticleSystem.EmitParams() {
                    startLifetime = lifetime,
                    velocity = new Vector2(
                        Mathf.Cos(i),
                        Mathf.Sin(i)
                    ) * speed,
                }, count);
            }
        }
    }
}
