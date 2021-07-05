using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class JoinRoom : MonoBehaviour
{
    [SerializeField] private Button createRoomTab;
    [SerializeField] private GameObject roomsContent;
    [SerializeField] private RoomListing roomPrefab;

    private void Start()
    {
        Network.Manager.roomsUpdated += DisplayRooms;
        createRoomTab.onClick.AddListener(() => CanvasManager.ChangeMenu("Create Room"));
    }

    private void DisplayRooms(List<RoomInfo> rooms)
    {
        foreach (Transform child in roomsContent.transform)
            GameObject.Destroy(child.gameObject);

        foreach (var room in rooms)
        {
            if (room.RemovedFromList) continue;

            var instance = Instantiate(roomPrefab, roomsContent.transform);
            instance.SetRoomInfos(room);
        }
    }
}
