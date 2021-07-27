using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Player
{
    public class Main : MonoBehaviourPun
    {
        public static GameObject local;
        public static Controller controller;

        void Start()
        {
            if (photonView.IsMine)
            {
                local = gameObject;

                InitLocal();
            }
            else
            {
                InitRemote();
            }
        }

        protected virtual void InitLocal() {}
        protected virtual void InitRemote() {}
    }
}