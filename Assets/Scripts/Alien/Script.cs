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

    public class Script : Player.Script, IPunInstantiateMagicCallback
    {
        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            var playerName = (string)info.photonView.InstantiationData[0];
            gameObject.name = $"(Alien) {playerName}";
        }
    }
}