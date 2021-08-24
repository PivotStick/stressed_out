using UnityEngine;

namespace Human
{
    public class Blood : MonoBehaviour
    {
        public ParticleSystem system;
        public ParticleSystem.EmissionModule emission;

        private bool isDragging = false;

        private float Rate
        {
            get => emission.rateOverTime.constant;
            set => emission.rateOverTime = value;
        }

        public bool IsDragging
        {
            get => isDragging;
            set
            {
                isDragging = value;
                if (isDragging) system.Play(); else system.Stop();
            }
        }

        public void DestroyOnFinish()
        {
            var main = system.main;
            main.stopAction = ParticleSystemStopAction.Destroy;
        }

        void Start()
        {
            system = GetComponent<ParticleSystem>();
            emission = system.emission;
            Rate = 20;
        }

        void FixedUpdate()
        {
            if (isDragging)
            {
                Rate -= Time.fixedDeltaTime;
                Rate = Mathf.Max(Rate, 0.5f);
            }
        }
    }
}