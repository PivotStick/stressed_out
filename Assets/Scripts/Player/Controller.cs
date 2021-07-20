using UnityEngine;
using Photon.Pun;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller : MonoBehaviourPun
    {
        [Header("Stats")]
		[SerializeField] protected float moveSpeed = 1.5f;
		[SerializeField] protected float minSpeed = 0.75f;
		[SerializeField] protected float maxSpeed = 2.5f;

        protected Rigidbody2D rbd;
        private Inputs inputs;

        void Awake()
        {
            rbd = GetComponent<Rigidbody2D>();
            inputs = new Inputs();
        }

        void FixedUpdate()
        {
            rbd.velocity = inputs.Movements.Move.ReadValue<Vector2>() * moveSpeed;
        }

        void OnEnable() => inputs.Enable();
        void OnDisable() => inputs.Disable();

        public virtual void SetEnabled(bool enabled)
        {
            if (enabled) inputs.Enable();
            else inputs.Disable();
        }
    }
}