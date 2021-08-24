using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

namespace Human
{
    public class Corpse : MonoBehaviourPun
    {
        public bool infectionStarted = false;

        private SpringJoint2D joint;
        private Alien.Inputs inputs;
        private Alien.Main alien;
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

        public void AttachTo(Alien.Main alien)
        {
            Debug.Log($"AttachTo {alien.name}");
            alien.isGrabbing = true;
            joint.connectedBody = alien.GetComponent<Rigidbody2D>();
            joint.enabled = true;
        }

        public void Detach()
        {
            Debug.Log("Detach");
            if (alien)
            {
                Debug.Log($"From {alien.name}");
                alien.isGrabbing = false;
                alien = null;
            }

            joint.connectedBody = null;
            joint.enabled = false;
        }

        void OnGrab(InputAction.CallbackContext _)
        {
            Debug.Log("OnGrab");
            alien = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(1.5f, 1.5f), 0).GetComponent<Alien.Main>();
            if (!alien && alien.photonView.IsMine) return;

            AttachTo(alien);
            Network.Event.Trigger(
                Network.Event.ID.CORPSE_DETACH,
                new object[] {
                    photonView.ViewID,
                    alien.photonView.ViewID,
                },
                receivers: Photon.Realtime.ReceiverGroup.Others
            );
        }

        void OnRelease(InputAction.CallbackContext _) => Release();
        public void Release()
        {
            Debug.Log("Release");
            Detach();
            Network.Event.Trigger(
                Network.Event.ID.CORPSE_DETACH,
                new object[] {
                    photonView.ViewID
                },
                receivers: Photon.Realtime.ReceiverGroup.Others
            );
        }

        void OnDestroy()
        {
            RemoveListeners();
            inputs.Disable();
        }

        void RemoveListeners()
        {
            blood.IsDragging = false;
            Release();
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
    }
}