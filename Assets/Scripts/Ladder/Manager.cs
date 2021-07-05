using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Ladder
{
	public class Manager : MonoBehaviourPun
	{
		public Floor[] floors;
		private int CurrentFloor { get => Player.Manager.GetProperty<int>("currentFloor"); }

		public void Start()
		{

		}
		void OnTriggerEnter2D(Collider2D collider2D)
		{
			Human.Script human = collider2D.GetComponent<Human.Script>();

			if (!human || !human.photonView.IsMine) return;

			if (CurrentFloor == 2)
				Player.Manager.SetProperty("currentFloor", 1);
			else
				Player.Manager.SetProperty("currentFloor", 2);

			Network.Event.floorChanged += OnPlayerChangedFloor;
		}

		private void OnPlayerChangedFloor(Photon.Realtime.Player player)
		{
			Network.Event.floorChanged -= OnPlayerChangedFloor;
			foreach (var floor in floors)
			{
				floor.OnChangeLevel(CurrentFloor);
			}
		}

		void OnTriggerExit2D(Collider2D collider2D)
		{
			Debug.Log("on quit l'echelle");
		}

	}
}

