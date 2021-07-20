using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alien
{
    public class Main : Player.Main
    {
        [SerializeField] private Material unlitMat;

        protected override void InitLocal()
        {
            gameObject.AddComponent<Controller>();
            var local = gameObject.AddComponent<Local>();

            local.unlitMat = unlitMat;
        }
    }
}
