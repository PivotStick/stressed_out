using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ladder
{
	public class Floor : MonoBehaviour
	{
		public int level = 0;

		public void Start()
		{
			int currentFloor = Player.Manager.GetProperty<int>("currentFloor");
			OnChangeLevel(currentFloor);
		}

		public void OnChangeLevel(int floorLevel)
		{
			gameObject.SetActive(level == floorLevel);
		}
	}
}

