using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Player
{
	public class Script : MonoBehaviourPun
    {
        private Controller controller;

		protected float maxHealth = 100f;
		protected float health;

        public bool IsDead {
            get => health <= 0;
        }

        void Awake()
        {
            controller = GetComponent<Controller>();
            health = maxHealth;
        }

		public virtual void Damage(float amount)
		{
			if (IsDead) return;

			health -= amount;
			health = Mathf.Clamp(health, 0, maxHealth);

			if (IsDead) Die();
        }

		public virtual void Die() {
            controller.DisableControls();
        }
    }
}