using UnityEngine;
using Photon.Pun;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller : MonoBehaviourPun
    {
        [Header("Stats")]
		public float moveSpeed = 1.5f;
		public float minSpeed = 0.75f;
		public float maxSpeed = 2.5f;

        protected Rigidbody2D rbd;
        private Inputs inputs;


        protected virtual void Awake()
        {
            rbd = GetComponent<Rigidbody2D>();
            inputs = new Inputs();
        }

        void FixedUpdate()
        {
            rbd.velocity = inputs.Movements.Move.ReadValue<Vector2>() * moveSpeed;
        }

        void OnEnable() => SetEnabled(true);
        void OnDisable() => SetEnabled(false);

        public virtual void SetEnabled(bool enabled)
        {
            if (enabled) inputs.Enable();
            else inputs.Disable();
        }
    }
}