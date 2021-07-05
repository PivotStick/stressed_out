using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button button;

    public void SetRoomInfos(RoomInfo room)
    {
        text.text = $"({room.PlayerCount}/{room.MaxPlayers}) \"{room.Name}\"";
        button.onClick.AddListener(() => {
            Network.Manager.instance.JoinRoom(room.Name);
            CanvasManager.ChangeMenu("Room Panel");
        });
    }
}
