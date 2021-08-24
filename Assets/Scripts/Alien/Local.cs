using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alien
{
    public class Local : MonoBehaviour
    {
        public Material unlitMat;
        public bool isGrabbing = false;

        private Controller controller;

        void Start()
        {
            controller = GetComponent<Controller>();
            GetComponent<SpriteRenderer>().material = unlitMat;
            Cam.Follower.target = gameObject;
            var filter = Camera.main.gameObject.AddComponent<AudioLowPassFilter>();

            filter.cutoffFrequency = 100;
        }

        void FixedUpdate()
        {
            if (isGrabbing)
                controller.moveSpeed = Mathf.Min(controller.maxSpeed - 1, controller.moveSpeed);
        }
    }
}