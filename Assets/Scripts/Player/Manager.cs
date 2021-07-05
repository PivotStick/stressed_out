using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Player
{
	public static class Manager
	{
		public static Photon.Realtime.Player[] players = new Photon.Realtime.Player[] { };

		public static Photon.Realtime.Player[] Humans { get => PlayersOfRole(RoleID.Human); }
		public static Photon.Realtime.Player[] Aliens { get => PlayersOfRole(RoleID.Alien); }
		public static Photon.Realtime.Player Me { get => PhotonNetwork.LocalPlayer; }
		public static RoleID MyRole { get => GetProperty<RoleID>("Role"); }

		public static GameObject Player
		{
			get
			{
				foreach (var o in GameObject.FindObjectsOfType<PhotonView>())
					if (o.IsMine && o.gameObject.CompareTag("Player")) return o.gameObject;

				return null;
			}
		}

		public static void SetProperty(string key, object value)
		{

			var props = new ExitGames.Client.Photon.Hashtable();
			props.Add(key, value);
			Me.SetCustomProperties(props);
		}

		public static T GetProperty<T>(string key)
		{
			return (T)Me.CustomProperties[key];
		}

		public static void InitProperties()
		{
			SetProperty("Role", RoleID.Human);
			SetProperty("isDead", false);
			SetProperty("currentFloor", 2);
		}

		private static Photon.Realtime.Player[] PlayersOfRole(RoleID role)
		{
			var results = new List<Photon.Realtime.Player>();

			foreach (var player in players)
				if ((RoleID)player.CustomProperties["Role"] == role)
					results.Add(player);

			return results.ToArray();
		}
	}
}