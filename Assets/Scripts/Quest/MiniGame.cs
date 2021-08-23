using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Quest
{
    public class MiniGame : MonoBehaviourPun
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
            Network.Event.questRepaired += Finish;
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
                photonView.ViewID
            });
        }

        public void Finish(int viewId)
        {
            if (photonView.ViewID != viewId) return;;

            finished?.Invoke();
            Visible = false;
        }

        void OnDestroy()
        {
            Network.Event.questRepaired -= Finish;
        }
    }
}
