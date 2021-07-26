using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;
using Photon.Voice;

namespace Human
{
    public class AudioResolver : MonoBehaviour
    {
        public LayerMask wallsMask;
        public AudioSource source;

        public AudioLowPassFilter filter;

        private float MaxDistance { get => 12; }
        private float CutoffFrequency
        {
            get => filter.cutoffFrequency;
            set => filter.cutoffFrequency += (value - filter.cutoffFrequency) * 0.1f;
        }


        void FixedUpdate()
        {
            ResolveDistance();
        }

        void ResolveDistance()
        {
            Vector3 start = Main.local.transform.position;
            Vector3 end = transform.position;
            RaycastHit2D hit = Physics2D.Linecast(start, end, wallsMask);

            float distance = Vector2.Distance(start, end);
            float percent = 1 - Mathf.Clamp01(distance / MaxDistance);
            float horizontalDiff = end.x - start.x;

            horizontalDiff = Mathf.Clamp(horizontalDiff / MaxDistance, -1, 1);

            CutoffFrequency = hit.collider != null
                ? percent * 2000
                : 22000;

            source.volume = percent;
            source.panStereo = horizontalDiff;
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, MaxDistance);
        }
#endif
    }
}