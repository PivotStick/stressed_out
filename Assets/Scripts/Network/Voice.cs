using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Realtime;

namespace Network
{
    public class Voice : MonoBehaviour
    {
        private static Voice instance = null;
        private VoiceConnection connection;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
                connection = GetComponent<VoiceConnection>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        static public void CreateRoom(string roomName)
        {
            instance.connection.Client.OpJoinOrCreateRoom(new EnterRoomParams()
            {
                RoomName = roomName,
            });
        }

        static public void JoinRoom(string roomName)
        {
            instance.connection.Client.OpJoinRoom(new EnterRoomParams()
            {
                RoomName = roomName
            });
        }

        static public void LeaveRoom()
        {
            instance.connection.Client.OpLeaveRoom(false);
        }
    }
}
