using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Player
{
	public class Script : MonoBehaviourPun
    {
		protected float maxHealth = 100f;
		protected float health;

        public bool IsDead { get => health <= 0; }

        void Awake()
        {
            health = maxHealth;
			Network.Event.floorChanged += OnPlayerChangedFloor;
        }

		public virtual void Damage(float amount)
		{
			if (IsDead) return;

			health -= amount;
			health = Mathf.Clamp(health, 0, maxHealth);

			if (IsDead) Die();
        }

		public virtual void Die() {}

		public void OnPlayerChangedFloor(Photon.Realtime.Player player)
		{
			int myFloor = Player.Manager.CurrentFloor;
			int otherFloor = (int)photonView.Owner.CustomProperties["currentFloor"];
			gameObject.SetActive(myFloor == otherFloor);
		}
    }
}
