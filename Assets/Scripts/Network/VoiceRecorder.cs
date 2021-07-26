using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Network
{
    public class VoiceRecorder : MonoBehaviour
    {
        private static VoiceRecorder instance = null;

        void Start()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}