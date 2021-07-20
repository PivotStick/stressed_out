using UnityEngine;

namespace Cam
{
    public class Follower : MonoBehaviour
    {
        static public GameObject target = null;

        private Vector2 Pos
        {
            get => transform.position;
            set => transform.position += (Vector3)(value - Pos * 0.1f);
        }

        void FixedUpdate()
        {
            if (target != null)
                Pos = target.transform.position;
        }
    }
}