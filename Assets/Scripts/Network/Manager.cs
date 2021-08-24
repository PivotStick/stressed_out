using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;

namespace Network
{
	public class Manager : MonoBehaviourPunCallbacks
	{
		public const int MAX_PLAYERS = 10;
		public GameObject speaker;

		public static Manager instance = null;

		public delegate void OnRoomJoined(Photon.Realtime.Player[] players, RoomInfo room);
		public delegate void OnRoomsUpdated(List<RoomInfo> roomList);
		public delegate void OnNickNameChanged(string nickName);
		public delegate void Callback();

		public static event OnRoomJoined roomJoined;
		public static event OnRoomsUpdated roomsUpdated;
		public static event OnNickNameChanged nickNameChanged;
		public static event Callback connected;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(instance);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private void Start()
		{
			PhotonNetwork.AutomaticallySyncScene = true;
			PhotonNetwork.ConnectUsingSettings();
		}

		public void CreateRoom(string roomName)
		{
			PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions
			{
				MaxPlayers = MAX_PLAYERS,
				BroadcastPropsChangeToAll = true,
			}, TypedLobby.Default);
		}

		public void JoinRoom(string roomName)
		{
			PhotonNetwork.JoinRoom(roomName);
		}

		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

		public void SetNickName(string nickName)
		{
			PhotonNetwork.NickName = nickName.Trim();
			nickNameChanged?.Invoke(PhotonNetwork.NickName);
		}

		private void InvokeRoomJoined()
		{
			Player.Manager.players = PhotonNetwork.PlayerList;
			roomJoined?.Invoke(
				PhotonNetwork.PlayerList,
				PhotonNetwork.CurrentRoom
			);
		}

		public IEnumerator LaunchGame()
		{
			Audio.Manager.instance.FadeOutBG();
			TransitionManager.instance.FadeIn();
			yield return new WaitForSeconds(3);
			SceneManager.LoadScene(1);
			TransitionManager.instance.FadeOut();
			CanvasManager.instance.gameObject.SetActive(false);
		}

		public PhotonView GetView(int viewId)
		{
			foreach (var view in FindObjectsOfType<PhotonView>())
				if (view.ViewID == viewId) return view;

			return null;
		}

		public bool IsMasterClient()
		{
			return PhotonNetwork.IsMasterClient;
		}

		public void InstantiateSpeaker()
		{
			VoiceRecorder.UnMute();
			PhotonNetwork.Instantiate(speaker.name, Vector3.zero, Quaternion.identity);
		}

		public override void OnJoinedRoom()
		{
			InvokeRoomJoined();
			InstantiateSpeaker();
		}

		public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
		{
			InvokeRoomJoined();
		}

		public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
		{
			InvokeRoomJoined();
		}

		public override void OnConnectedToMaster()
		{
			connected?.Invoke();
			PhotonNetwork.JoinLobby();
			Player.Manager.InitProperties();
		}

		public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
		{
			var isDead = (bool)(changedProps["isDead"] ?? false);
			int currentFloor = (int)(changedProps["currentFloor"] ?? -1);

			if (isDead == true)
				Event.Trigger(Event.ID.PLAYER_DIED);

			if (currentFloor != -1)
				Event.Trigger(Event.ID.PLAYER_CHANGED_FLOOR, new object[] { targetPlayer.UserId });
		}

		public override void OnRoomListUpdate(List<RoomInfo> roomList)
		{
			roomsUpdated?.Invoke(roomList);
		}
	}
}