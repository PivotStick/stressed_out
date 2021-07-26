using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Human
{
	public class Script : Player.Script, IPunInstantiateMagicCallback
	{
		[SerializeField] private GameObject pointLight;
		[SerializeField] private ParticleSystem blood;
		[SerializeField] private Material unlit;
		[SerializeField] private Material lit;
		[SerializeField] private GameObject ghostPrefab;

		private void SetParticleMaterial(Material material)
		{
			var pr = blood.GetComponent<ParticleSystemRenderer>();
			pr.material = material;
			pr.trailMaterial = material;
		}

		public void Start()
		{
			pointLight.SetActive(photonView.IsMine);
			SetParticleMaterial(lit);
			if (Player.Manager.MyRole == Player.RoleID.Alien)
				SetParticleMaterial(unlit);
		}

		public override void Damage(float amount)
		{
			base.Damage(amount);
			blood.Emit((int)(amount / 3));
		}

		public override void Die()
		{
			base.Die();

			var main = blood.main;
			main.startLifetime = 25;
			blood.Emit(35);
			Destroy(Main.controller);

			if (photonView.IsMine)
			{
				var ghost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
				pointLight.SetActive(false);
				ghost.name = $"#DEAD {gameObject.name}";
				Cam.Follower.target = ghost;

				Player.Manager.SetProperty("isDead", true);
			}
		}

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
			var playerName = (string)info.photonView.InstantiationData[0];
			gameObject.name = $"(Human) {playerName}";
		}
	}
}