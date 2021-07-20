using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

namespace Human
{
    public class Main : Player.Main
    {
        public LayerMask wallsMask;
        public ParticleSystem system;

        protected override void InitLocal()
        {
            gameObject.AddComponent<Controller>();
        }

        protected override void InitRemote()
        {
            var source = gameObject.AddComponent<AudioSource>();
            var speaker = gameObject.AddComponent<Speaker>();
            var resolver = gameObject.AddComponent<AudioResolver>();

            resolver.source = source;
            resolver.wallsMask = wallsMask;

            GetComponent<PhotonVoiceView>().SpeakerInUse = speaker;

            if (Player.Manager.MyRole == Player.RoleID.Alien)
            {
                var emitter = gameObject.AddComponent<SoundParticleEmitter>();
                var systemInstance = Instantiate(system);
                systemInstance.gameObject.transform.SetParent(transform);
                emitter.particles = systemInstance;
            }
        }
    }
}
