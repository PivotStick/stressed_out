using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance = null;

    [SerializeField] private Text nickNameText;
    [SerializeField] private GameObject[] menus;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }

        Network.Manager.connected += OnConnected;
        Network.Manager.nickNameChanged += (nickName) => {
            nickNameText.text = nickName;
        };

        gameObject.SetActive(PhotonNetwork.IsConnected);
        if (Player.Manager.Me.NickName == "")
            ChangeMenu("NickName");
        else
            ChangeMenu("Join Room");
    }

    private void OnConnected()
    {
        gameObject.SetActive(true);
    }

    public static void ChangeMenu(string menuName)
    {
        foreach (var menu in instance.menus)
            menu.SetActive(menu.name == menuName);
    }
}
