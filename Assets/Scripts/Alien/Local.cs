using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alien
{
    public class Local : MonoBehaviour
    {
        public Material unlitMat;

        void Start()
        {
            GetComponent<SpriteRenderer>().material = unlitMat;
            Cam.Follower.target = gameObject;
            var filter = Camera.main.gameObject.AddComponent<AudioLowPassFilter>();

            filter.cutoffFrequency = 100;
        }

    }
}