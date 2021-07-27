using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public enum ID
    {
        Roar,
        LoudStep,
        HumanStep,
        AlienBreath,
        AlienTail,
        AlienWarningBreath,
        OpenDoor,
        CloseDoor,
    }

    [CreateAssetMenu(fileName = "New Sound", menuName = "Scriptable Sound")]
    public class Scriptable : ScriptableObject
    {
        public static Scriptable[] sounds;
        public static Scriptable GetById(ID id)
        {
            foreach (var s in sounds)
                if (s.id == id) return s;

            return null;
        }

        public ID id;
        public AudioClip[] clips;
        public float sensivity = 0;
        public LayerMask collisionMask;

        public float alienDistance = 2;
        public float maxDistance = 10f;

        public bool loop = false;

        public int RandomIndex
        {
            get => Random.Range(0, clips.Length);
        }
    }
}