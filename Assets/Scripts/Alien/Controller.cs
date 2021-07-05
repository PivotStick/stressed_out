using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Alien
{
    [RequireComponent(typeof (Rigidbody2D))]
    public class Controller : Player.Controller
    {
        [SerializeField] private PolygonCollider2D attack;

        private Inputs inputs;
        private float stepTimer = 0f;

        private float roarFrequency = 3f;
        private float roarTimer = 0f;

        private float breathTimeout;
        private float breathTimer;

        private float warningTimeout = 4;
        private float warningTimer;

        private void Start()
        {
            moveSpeed = 0.75f;
            minSpeed = 0.75f;
            maxSpeed = 4f;

            if (!photonView.IsMine) return;

            inputs = new Inputs();
            inputs.Movements.Speed.performed += OnSpeedChange;

            inputs.Sounds.Roar.performed += _ => OnRoar();
            inputs.Sounds.Warning.performed += _ => OnWarning();
            inputs.Attacks.Swipe.performed += _ => OnAttack();

            roarTimer = roarFrequency;
            warningTimer = warningTimeout;
            attack.gameObject.SetActive(false);
            inputs.Enable();

        }

        private void Update()
        {
            if (!photonView.IsMine) return;

            if (rbd.velocity.magnitude > 0)
                Step();
            
            if (roarTimer < roarFrequency) roarTimer += Time.deltaTime;

            breathTimer += Time.deltaTime;
            warningTimer += Time.deltaTime;

            Breath();
        }

        private void OnWarning()
        {
            if (warningTimer < warningTimeout) return;

            warningTimer = 0;
            breathTimer = 0;

            MakeMouthSound(Audio.ID.AlienWarningBreath,
                particleMultiplier: 3
            );
        }

        private void Breath()
        {
            if (breathTimer < breathTimeout) return;

            breathTimer = 0;
            breathTimeout = Random.Range(4f, 5f);

            MakeMouthSound(Audio.ID.AlienBreath);
        }

        private void OnAttack()
        {
            var mousePos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            var screenPos = Camera.main.WorldToViewportPoint(transform.position);
            var diff = mousePos - screenPos;
            float diffAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            StartCoroutine(Attack(diffAngle));
        }

        private IEnumerator Attack(float angle)
        {

            attack.gameObject.SetActive(true);
            attack.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            yield return new WaitForSeconds(.5f);
            attack.gameObject.SetActive(false);
        }

        private void Step()
        {
            stepTimer += Time.deltaTime;
            if (stepTimer < 1 / moveSpeed) return;

            stepTimer = 0;
            var percent = moveSpeed / maxSpeed;
            Audio.Manager.instance.PlaySoundAt(transform.position, Audio.ID.LoudStep, percent,
                speedMultiplier: percent * 3,
                particleMultiplier: percent * 3f
            );
        }

        private void OnSpeedChange(InputAction.CallbackContext ctx)
        {
            float speed = ctx.ReadValue<float>();
            moveSpeed += speed / 1000;
            moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);
        }

        private void OnRoar()
        {
            if (roarTimer < roarFrequency) return;

            roarTimer = 0;
            MakeMouthSound(Audio.ID.Roar,
                speedMultiplier: 4,
                particleMultiplier: 2
            );
        }

        private void OnDisable()
        {
            inputs.Disable();
        }

        private void MakeMouthSound(Audio.ID sound, float volume = 1, float speedMultiplier = 1, float particleMultiplier = 1)
        {
            Audio.Manager.instance.PlaySoundAt(
                transform.position,
                sound,
                volume,
                photonView.ViewID,
                particleMultiplier,
                speedMultiplier
            );
        }
    }
}