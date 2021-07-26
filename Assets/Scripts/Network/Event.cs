using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

namespace Network
{
	public class Event : MonoBehaviour
	{
		public enum ID
		{
			LAUNCH_GAME,
			DAMAGE_PLAYER,
			PLAYER_DIED,
			PLAYER_CHANGED_FLOOR,
		}

		public static Event instance = null;

		public delegate void OnFloorChanged(Photon.Realtime.Player player);

		public static event OnFloorChanged floorChanged;

		private void OnEnable() => PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
		private void OnDisable() => PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			} else {
				Destroy(gameObject);
			}
		}

		public static void TriggerEvent(ID eventId, object[] datas = null)
		{
			var options = new Photon.Realtime.RaiseEventOptions { Receivers = Photon.Realtime.ReceiverGroup.All };
			PhotonNetwork.RaiseEvent((byte)eventId, datas, options, SendOptions.SendReliable);
		}

		public void OnEvent(EventData data)
		{
			switch ((ID)data.Code)
			{
				case ID.LAUNCH_GAME: LaunchGame(); break;
				case ID.DAMAGE_PLAYER: DamagePlayer((object[])data.CustomData); break;
				case ID.PLAYER_DIED: PlayerDied(); break;
				case ID.PLAYER_CHANGED_FLOOR: FloorChanged(((object[])data.CustomData)[0]); break;
			}
		}

		private void FloorChanged(object userId)
		{
			var players = PhotonNetwork.PlayerList;

			foreach (var player in players)
			{
				if (player.UserId == (string)userId)
				{
					floorChanged?.Invoke(player);
					break;
				}
			}
		}

		private void PlayerDied()
		{
			var humans = Player.Manager.Humans;
			var aliveCount = humans.Length;

			foreach (var human in humans)
				if ((bool)human.CustomProperties["isDead"])
					aliveCount--;

			if (aliveCount == 0)
				StartCoroutine(TransitionManager.instance.GameOver());
		}

		private void DamagePlayer(object[] data)
		{
			var viewId = (int)data[0];
			var damage = (float)data[1];

			var objects = FindObjectsOfType<PhotonView>();
			Human.Script player = null;
			foreach (var item in objects)
				if (item.ViewID == viewId)
				{
					player = item.GetComponent<Human.Script>();
					break;
				}

			player.Damage(damage);
		}

		private void LaunchGame()
		{
			StartCoroutine(Manager.instance.LaunchGame());
		}
	}
}