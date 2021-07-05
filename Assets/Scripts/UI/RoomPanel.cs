using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class RoomPanel : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private Button playButton;
    [SerializeField] private Button leaveRoomTab;
    [SerializeField] private PlayerRoom playerPrefab;

    private void Start()
    {
        Network.Manager.roomJoined += DisplayPlayers;
        leaveRoomTab.onClick.AddListener(LeaveRoomTabs);
        playButton.onClick.AddListener(OnLaunchGame);
    }

    private void OnEnable() => DisplayButton();

    private void DisplayPlayers(Photon.Realtime.Player[] players, RoomInfo room)
    {
        DisplayButton();
        playButton.interactable = players.Length > 1;
        Player.Manager.players = players;

        foreach (Transform child in content.transform)
            GameObject.Destroy(child.gameObject);

        foreach (var player in players)
        {
            var instance = Instantiate(playerPrefab, content.transform);
            instance.SetPlayerInfo(player);
        }
    }

    private void OnLaunchGame()
    {
        // AddRandomAlien();

        // var players = Player.Manager.players;

        // if(players.Length > 5)
        // {
        //     AddRandomAlien();
        // } 

        Player.Manager.SetProperty("Role", Player.RoleID.Alien);
        Network.Event.TriggerEvent(Network.Event.ID.LAUNCH_GAME);
    }

    private void DisplayButton()
    {
        if (Network.Manager.instance != null)
            playButton.gameObject.SetActive(Network.Manager.instance.IsMasterClient());
    }

    private void LeaveRoomTabs()
    {
        CanvasManager.ChangeMenu("Join Room");
        Network.Manager.instance.LeaveRoom();
    }

    private void AddRandomAlien()
    {
        var players = Player.Manager.players;

        int randomIndex = Random.Range(0, players.Length);
        Player.RoleID role = (Player.RoleID)players[randomIndex].CustomProperties["Role"];

        while (role != Player.RoleID.Human)
        {
            randomIndex = Random.Range(0, players.Length);
            role = (Player.RoleID)players[randomIndex].CustomProperties["Role"];
        }

        var props = new Hashtable();

        props.Add("Role", Player.RoleID.Alien);

        players[randomIndex].SetCustomProperties(props);
    }

    private void SetRoleTo(Photon.Realtime.Player player, Player.RoleID role)
    {
        var props = new Hashtable();
        props.Add("Role", role);
        player.SetCustomProperties(props);
    }
}
