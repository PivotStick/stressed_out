using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class MiniGame : MonoBehaviour
    {
        public static int count = 0;

        public delegate void OnClose();
        public delegate void OnFinished();

        public event OnClose close;
        public event OnFinished finished;

        public Button closeButton;
        public string id;

        protected AudioSource gameAudio;

        virtual protected void Awake()
        {
            closeButton.onClick.AddListener(Close);
            gameAudio = GetComponent<AudioSource>();
            Network.Event.questRepaired += Finish;
            count++;
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
            Network.Event.TriggerEvent(Network.Event.ID.QUEST_REPAIRED, new object[] {
                id
            });
        }

        public void Finish(string id)
        {
            if (this.id != id) return;
            count--;

            finished?.Invoke();
            Visible = false;
        }

        void OnDestroy()
        {
            Network.Event.questRepaired -= Finish;
        }
    }
}
