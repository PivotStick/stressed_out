using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
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
			QUEST_REPAIRED,
			CORPSE_DRAG,
			CORPSE_DETACH,
		}

		public static Event instance = null;

		public delegate void OnFloorChanged(Photon.Realtime.Player player);
		public delegate void OnQuestRepaired(string viewId);

		public static event OnFloorChanged floorChanged;
		public static event OnQuestRepaired questRepaired;

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

		public static void Trigger(ID eventId, object[] datas = null, ReceiverGroup receivers = ReceiverGroup.All)
		{
			var options = new RaiseEventOptions { Receivers = receivers };
			PhotonNetwork.RaiseEvent((byte)eventId, datas, options, SendOptions.SendReliable);
		}

		public void OnEvent(EventData data)
		{
			var customData = (object[])data.CustomData;
			switch ((ID)data.Code)
			{
				case ID.LAUNCH_GAME: LaunchGame(); break;
				case ID.DAMAGE_PLAYER: DamagePlayer(customData); break;
				case ID.PLAYER_DIED: PlayerDied(); break;
				case ID.PLAYER_CHANGED_FLOOR: FloorChanged(customData[0]); break;
				case ID.QUEST_REPAIRED: QuestRepaired((string)customData[0]); break;
				case ID.CORPSE_DETACH: DetachCorpse((int)customData[0]); break;
				case ID.CORPSE_DRAG: DragCorpse(customData); break;
			}
		}

		private void DragCorpse(object[] data)
		{
			var corpseId = (int)data[0];
			var alienId = (int)data[1];

			var corpse = Manager.instance.GetView(corpseId).GetComponent<Human.Corpse>();
			var alien = Manager.instance.GetView(alienId).GetComponent<Alien.Main>();

			corpse.AttachTo(alien);
		}

		private void DetachCorpse(int viewId)
		{
			var corpse = Manager.instance.GetView(viewId).GetComponent<Human.Corpse>();
			corpse.Detach();
		}

		private void QuestRepaired(string viewId)
		{
			questRepaired?.Invoke(viewId);
		}

		private void FloorChanged(object userId)
		{
			var players = PhotonNetwork.PlayerList;

			foreach (var player in players)
				if (player.UserId == (string)userId)
				{
					floorChanged?.Invoke(player);
					break;
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
				GameOver();
		}

		public void GameOver()
		{
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