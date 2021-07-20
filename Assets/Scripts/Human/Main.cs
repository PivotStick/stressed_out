using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

namespace Human
{
    public class Main : Player.Main
    {
        protected override void InitLocal()
        {
            gameObject.AddComponent<Controller>();
        }

        protected override void InitRemote()
        {
            gameObject.AddComponent<AudioSource>();
            var speaker = gameObject.AddComponent<Speaker>();
            GetComponent<PhotonVoiceView>().SpeakerInUse = speaker;
        }
    }
}
