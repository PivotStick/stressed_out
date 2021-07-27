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
        private bool touching = false;

        public bool Open
        {
            get => animator.GetBool("open");
            set => animator.SetBool("open", value);
        }

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            trigger = GetComponent<Collider2D>();
            animator.speed = speed;
        }

        void FixedUpdate()
        {
            touching = trigger.IsTouchingLayers(triggeringLayers);
            if (!Open && touching)
            {
                Open = true;
                Audio.Manager.instance.PlayLocalAt(
                    transform.position,
                    Audio.ID.OpenDoor
                );
            }
            else if (Open && !touching)
            {
                Open = false;
                Audio.Manager.instance.PlayLocalAt(
                    transform.position,
                    Audio.ID.CloseDoor
                );
            }
        }
    }
}
