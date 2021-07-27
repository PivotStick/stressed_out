using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Quest
{
    public class MiniGame : MonoBehaviour
    {
        public delegate void OnClose();
        public delegate void OnFinished();

        public event OnClose close;
        public event OnFinished finished;

        public Button closeButton;

        protected AudioSource gameAudio;

        virtual protected void Awake()
        {
            closeButton.onClick.AddListener(Close);
            gameAudio = GetComponent<AudioSource>();
        }

        public bool Visible
        {
            get => gameObject.activeInHierarchy;
            set
            {
                gameObject.SetActive(value);
                Player.Main.controller.SetEnabled(!value);
            }
        }

        public void Close()
        {
            close?.Invoke();
            Visible = false;
        }

        public void Finish()
        {
            finished?.Invoke();
            Visible = true;
        }
    }
}
