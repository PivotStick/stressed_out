using UnityEngine;
using Photon.Pun;

namespace Human
{
	public class Script : Player.Script, IPunInstantiateMagicCallback
	{
		[SerializeField] private GameObject pointLight;
		[SerializeField] private Blood blood;
		[SerializeField] private Material unlit;
		[SerializeField] private Material lit;
		[SerializeField] private GameObject ghostPrefab;

		private Main mainScript;

		private void SetParticleMaterial(Material material)
		{
			var pr = blood.GetComponent<ParticleSystemRenderer>();
			pr.material = material;
			pr.trailMaterial = material;
		}

		public void Start()
		{
			blood = GetComponentInChildren<Blood>();
			mainScript = GetComponent<Main>();
			pointLight.SetActive(photonView.IsMine);

			SetParticleMaterial(
				Player.Manager.MyRole == Player.RoleID.Alien
					? unlit
					: lit
			);
		}

		public override void Damage(float amount)
		{
			base.Damage(amount);
			blood.system.Emit((int)(amount / 3));
		}

		public override void Die()
		{
			base.Die();

			blood.system.Emit(35);

			if (photonView.IsMine)
			{
				var ghost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
				pointLight.SetActive(false);
				ghost.name = $"#DEAD {gameObject.name}";
				Cam.Follower.target = ghost;

				Player.Manager.SetProperty("isDead", true);
			}

			mainScript.DestroyComponents();
			gameObject.AddComponent<Corpse>();
			Network.VoiceRecorder.Mute();
		}

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
			var playerName = (string)info.photonView.InstantiationData[0];
			gameObject.name = $"(Human) {playerName}";
		}
	}
}