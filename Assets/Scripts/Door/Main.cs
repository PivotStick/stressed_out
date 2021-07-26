using UnityEngine;

namespace Door
{
    [RequireComponent(typeof(Collider2D))]
    public class Main : MonoBehaviour
    {
        public LayerMask triggeringLayers;
        public float speed = 1f;

        private Animator animator;
        private Collider2D trigger;

        public bool Open { set => animator.SetBool("open", value); }

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            trigger = GetComponent<Collider2D>();
            animator.speed = speed;
        }

        void FixedUpdate()
        {
            Open = trigger.IsTouchingLayers(triggeringLayers);
        }
    }
}
