using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRoom : MonoBehaviour
{
    [SerializeField] private Text text;

    public void SetPlayerInfo(Photon.Realtime.Player player)
    {
        text.text = player.NickName;
    }
}
