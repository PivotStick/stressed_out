using UnityEngine;

namespace Human
{
	public class Controller : Player.Controller
	{
		private Inputs inputs;
		private float stepTimer = 0;

		void Start()
		{
			moveSpeed = 1.5f;
			minSpeed = 0.75f;
			maxSpeed = 2.5f;

			inputs = new Inputs();
			if (photonView.IsMine)
			{
				inputs.Enable();

				Cam.Follower.target = gameObject;

				inputs.Movements.Sprint.performed += _ => SetSpeed(maxSpeed);
				inputs.Movements.Walk.performed += _ => SetSpeed(minSpeed);

				inputs.Movements.Sprint.canceled += _ => SetSpeed();
				inputs.Movements.Walk.canceled += _ => SetSpeed();
			}
		}

		void SetSpeed(float speed = 1.5f)
		{
			moveSpeed = Mathf.Clamp(speed, minSpeed, maxSpeed);
		}

		void Update()
		{
			if (!photonView.IsMine) return;

			if (rbd.velocity.magnitude > 0)
				Step();
		}

		private void Step()
		{
			stepTimer += Time.deltaTime;
			if (stepTimer < maxSpeed - moveSpeed + 0.35f) return;
			stepTimer = 0;

			var percent = moveSpeed / maxSpeed;
			Audio.Manager.instance.PlaySoundAt(
				transform.position,
				Audio.ID.HumanStep,
				Player.Manager.CurrentFloor,

				volume: percent,
				particleMultiplier: percent * 10,
				speedMultiplier: percent * 6
			);
		}

		private void OnDisable() => inputs.Disable();

        public override void DisableControls()
        {
			base.DisableControls();
			inputs.Disable();
		}
	}
}