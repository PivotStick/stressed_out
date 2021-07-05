using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    [SerializeField] private InputField nickNameField;
    [SerializeField] private Button submitButton;

    private void Start()
    {
        nickNameField.onValueChanged.AddListener(OnChange);
        submitButton.onClick.AddListener(OnSubmit);

        OnChange(nickNameField.text);
    }

    private void OnChange(string value)
    {
        value = value.Trim();
        if (value.Length > 15)
            value = value.Substring(0, 14);

        submitButton.enabled = value != "";
        nickNameField.SetTextWithoutNotify(value);
    }

    private void OnSubmit()
    {
        Network.Manager.instance.SetNickName(nickNameField.text);
        CanvasManager.ChangeMenu("Join Room");
    }
}
