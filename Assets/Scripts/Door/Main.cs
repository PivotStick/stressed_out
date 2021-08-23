using UnityEngine;

namespace Door
{
    [RequireComponent(typeof(Collider2D))]
    public class Main : MonoBehaviour
    {
        public LayerMask triggeringLayers;
        public float speed = 1f;
        public int floorLevel = 1;

        private Animator animator;
        private Collider2D trigger;

        public bool Open
        {
            get => animator.GetBool("open");
            set 
            {
                if (Open == value) return;
                animator.SetBool("open", value);
                PlaySound(value);
            }
        }

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

        private void PlaySound(bool open)
        {
            Audio.Manager.instance.PlayLocalAt(
                transform.position,
                open ? Audio.ID.OpenDoor : Audio.ID.CloseDoor,
                floorLevel,
                speedMultiplier: 2,
                particleMultiplier: 2
            );
        }
    }
}
