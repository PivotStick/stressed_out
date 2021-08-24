using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;

namespace Network
{
    public class VoiceRecorder : MonoBehaviour
    {
        private static VoiceRecorder instance = null;
        private PhotonVoiceNetwork network;

        void Start()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                network = GetComponent<PhotonVoiceNetwork>();
            } else {
                Destroy(gameObject);
            }
        }

        public static void Mute()
        {
            instance.network.PrimaryRecorder.StopRecording();
        }

        public static void UnMute()
        {
            instance.network.PrimaryRecorder.StartRecording();
        }
    }
}