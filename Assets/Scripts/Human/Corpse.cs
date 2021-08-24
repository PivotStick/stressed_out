using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

namespace Human
{
    public class Corpse : MonoBehaviourPun, IPunOwnershipCallbacks
    {
        public bool infectionStarted = false;

        private SpringJoint2D joint;
        private Alien.Inputs inputs;
        private Alien.Local alien;
        private Rigidbody2D rbd;
        private Blood blood;
        private Animator animator;

        void Awake()
        {
            name = "Corpse";
            animator = GetComponent<Animator>();
            animator.SetBool("dead", true);

            joint = gameObject.AddComponent<SpringJoint2D>();
            joint.enableCollision = true;
            joint.autoConfigureDistance = false;
            joint.frequency = 1.5f;
            joint.distance = 0.5f;
            joint.enabled = false;

            rbd = GetComponent<Rigidbody2D>();
            blood = GetComponentInChildren<Blood>();

            inputs = new Alien.Inputs();
            if (Player.Manager.MyRole == Player.RoleID.Alien)
            {
                inputs.Enable();

                inputs.Movements.Grab.performed += OnGrab;
                inputs.Movements.Grab.canceled += OnRelease;       
            }
        }

        void OnGrab(InputAction.CallbackContext _) => OnGrab();
        void OnGrab()
        {
            photonView.RequestOwnership();
            alien = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(1.5f, 1.5f), 0).GetComponent<Alien.Local>();
            if (!alien) return;

            alien.isGrabbing = true;
            joint.connectedBody = alien.GetComponent<Rigidbody2D>();
            joint.enabled = true;
        }

        void OnRelease(InputAction.CallbackContext _) => OnRelease();
        void OnRelease()
        {
            if (alien)
            {
                alien.isGrabbing = false;
                alien = null;
            }

            joint.connectedBody = null;
            joint.enabled = false;
        }

        void OnDestroy()
        {
            RemoveListeners();
            inputs.Disable();
        }

        void RemoveListeners()
        {
            blood.IsDragging = false;
            OnRelease();
            inputs.Movements.Grab.performed -= OnGrab;
            inputs.Movements.Grab.canceled -= OnRelease;       
        }

        public void StartInfection()
        {
            infectionStarted = true;
            Destroy(GetComponent<Collider2D>());
            Destroy(joint);
            Destroy(rbd);
            RemoveListeners();
        }

        public Infected Infect()
        {
            blood.DestroyOnFinish();
            Destroy(this);
            return gameObject.AddComponent<Infected>();
        }

        void FixedUpdate()
        {
            if (infectionStarted) return;

            var isMoving = rbd.velocity.magnitude > 0.5f;
            if (joint.enabled && !blood.IsDragging && isMoving)
            {
                blood.IsDragging = true;
            }
            else if (blood.IsDragging && !isMoving)
            {
                blood.IsDragging = false;
            }
        }

        public void OnOwnershipRequest(PhotonView targetView, Photon.Realtime.Player requestingPlayer)
        {
            targetView.TransferOwnership(requestingPlayer);
        }

        public void OnOwnershipTransfered(PhotonView targetView, Photon.Realtime.Player previousOwner)
        {
        }

        public void OnOwnershipTransferFailed(PhotonView targetView, Photon.Realtime.Player senderOfFailedRequest)
        {
        }
    }
}