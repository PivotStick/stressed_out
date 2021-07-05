using UnityEngine;
using UnityEngine.UI;

public class CreateAndJoin : MonoBehaviour
{
    [SerializeField] private InputField roomNameField;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button joinRoomTab;

    private void Start()
    {
        roomNameField.onValueChanged.AddListener(OnChange);
        submitButton.onClick.AddListener(OnSubmit);
        joinRoomTab.onClick.AddListener(() => CanvasManager.ChangeMenu("Join Room"));
    }

    public void OnChange(string value)
    {
        submitButton.enabled = !string.IsNullOrEmpty(value);
    }

    public void OnSubmit()
    {
        string roomName = roomNameField.text.Trim();

        Network.Manager.instance.CreateRoom(roomName);
        Network.Manager.instance.JoinRoom(roomName);
        CanvasManager.ChangeMenu("Room Panel");
    }
}
