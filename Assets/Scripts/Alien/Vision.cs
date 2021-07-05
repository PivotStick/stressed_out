using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Alien
{
    public enum LayerID
    {
        ALIEN = 3,
    }

    public class Vision : MonoBehaviourPun, IPunInstantiateMagicCallback
    {
        [SerializeField] private Material unlitMat;

        private void Start()
        {
            if (!photonView.IsMine) return;

            GetComponent<SpriteRenderer>().material = unlitMat;
            Cam.Follower.target = gameObject;
            var filter = Camera.main.gameObject.AddComponent<AudioLowPassFilter>();

            filter.cutoffFrequency = 100;
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            var playerName = (string)info.photonView.InstantiationData[0];
            gameObject.name = $"(Alien) {playerName}";
        }
    }
}