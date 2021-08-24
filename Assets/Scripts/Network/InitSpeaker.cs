using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

namespace Network
{
    public class InitSpeaker : MonoBehaviourPun, IPunInstantiateMagicCallback
    {
        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            if (!photonView.IsMine)
            {
                var speaker = gameObject.AddComponent<Speaker>();
                GetComponent<PhotonVoiceView>().SpeakerInUse = speaker;
            }
        }
    }
}
