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

        public List<Component> components = new List<Component>();

        protected override void InitLocal()
        {
            controller = gameObject.AddComponent<Controller>();
            components.Add(controller);
        }

        protected override void InitRemote()
        {
            var source = gameObject.AddComponent<AudioSource>();
            var speaker = gameObject.AddComponent<Speaker>();
            var resolver = gameObject.AddComponent<AudioResolver>();
            var filter = gameObject.AddComponent<AudioLowPassFilter>();
            var voiceView = GetComponent<PhotonVoiceView>();

            components.Add(speaker);
            components.Add(filter);
            components.Add(resolver);
            components.Add(source);

            resolver.source = source;
            resolver.wallsMask = wallsMask;
            resolver.filter = filter;

            voiceView.SpeakerInUse = speaker;

            if (Player.Manager.MyRole == Player.RoleID.Alien)
            {
                var emitter = gameObject.AddComponent<SoundParticleEmitter>();
                var systemInstance = Instantiate(system);

                components.Add(emitter);
                components.Add(systemInstance);

                systemInstance.gameObject.transform.SetParent(transform);
                systemInstance.gameObject.transform.position = transform.position;
                emitter.particles = systemInstance;
            }
        }

        public void DestroyComponents()
        {
            components.ForEach(Destroy);
            Destroy(this);
        }
    }
}
