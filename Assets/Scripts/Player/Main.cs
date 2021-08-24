using UnityEngine;
using Photon.Pun;

namespace Player
{
    public class Main : MonoBehaviourPun
    {
        public static GameObject local
        {
            get => Cam.Follower.target;
            set => Cam.Follower.target = value;
        }
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