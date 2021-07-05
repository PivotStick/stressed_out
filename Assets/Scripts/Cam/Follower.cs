using UnityEngine;

namespace Cam
{
    public class Follower : MonoBehaviour
    {
        static public GameObject target = null;

        private Vector2 diff;

        void FixedUpdate()
        {
            if (target != null)
            {
                diff = target.transform.position - transform.position;
                transform.position += (Vector3)(diff * 0.1f);
            }
        }
    }
}