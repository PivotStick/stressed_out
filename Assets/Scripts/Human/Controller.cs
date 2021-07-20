using UnityEngine;

namespace Human
{
	public class Controller : Player.Controller
	{
		private float stepTimer = 0;
		private Inputs inputs;

        protected override void Awake()
        {
            base.Awake();

			moveSpeed = 1.5f;
			minSpeed = 0.75f;
			maxSpeed = 2.5f;

			inputs = new Inputs();

			Cam.Follower.target = gameObject;

			inputs.Movements.Sprint.performed += _ => SetSpeed(maxSpeed);
			inputs.Movements.Walk.performed += _ => SetSpeed(minSpeed);

			inputs.Movements.Sprint.canceled += _ => SetSpeed();
			inputs.Movements.Walk.canceled += _ => SetSpeed();
		}

		void SetSpeed(float speed = 1.5f)
		{
			moveSpeed = Mathf.Clamp(speed, minSpeed, maxSpeed);
		}

		void Update()
		{
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
		private void OnEnalbe() => inputs.Enable();

		public override void SetEnabled(bool enabled)
		{
			base.SetEnabled(enabled);

			if (enabled) inputs.Enable();
			else inputs.Disable();
		}
	}
}