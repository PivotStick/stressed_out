using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Ladder
{
	public class Manager : MonoBehaviourPun
	{
		public Floor[] floors;

		void OnTriggerEnter2D(Collider2D collider2D)
		{
			Player.Script player = collider2D.GetComponent<Player.Script>();

			if (!player || !player.photonView.IsMine) return;

			Debug.Log($"{player.gameObject.name} is entering");

			Player.Manager.SetProperty(
				"currentFloor",
				Player.Manager.CurrentFloor == 2 ? 1 : 2
			);

			Network.Event.floorChanged += OnPlayerChangedFloor;
		}

		private void OnPlayerChangedFloor(Photon.Realtime.Player player)
		{
			Network.Event.floorChanged -= OnPlayerChangedFloor;
			foreach (var floor in floors)
			{
				floor.OnChangeLevel(Player.Manager.CurrentFloor);
			}
		}
	}
}

