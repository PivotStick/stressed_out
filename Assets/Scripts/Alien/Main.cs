using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alien
{
    public class Main : Player.Main
    {
        public bool isGrabbing = false;

        [SerializeField] private Material unlitMat;

        void Start()
        {
            controller = GetComponent<Controller>();
        }

        void FixedUpdate()
        {
            if (isGrabbing)
                controller.moveSpeed = Mathf.Min(controller.maxSpeed - 1, controller.moveSpeed);
        }

        protected override void InitLocal()
        {
            controller = gameObject.AddComponent<Controller>();
            var local = gameObject.AddComponent<Local>();

            local.unlitMat = unlitMat;
        }
    }
}
