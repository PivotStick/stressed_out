using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class Main : MonoBehaviour
    {
        public Settings settings;
        public string id;

        private MiniGame miniGame;
        private bool isFinished = false;
        public bool IsFinished { get => isFinished; }

        private SpriteRenderer sprite;

        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = settings.brokenSprite;
            Network.Event.questRepaired += OnFinished;
        }

        public void OpenQuest()
        {
            if (isFinished) return;
            if (!miniGame)
            {
                miniGame = Instantiate(settings.miniGame);
                miniGame.id = id;
            }

            miniGame.Visible = true;
            miniGame.finished += OnFinished;
            miniGame.close += RemoveListeners;
        }

        void OnFinished()
        {
            RemoveListeners();
            Repair();
        }

        void OnFinished(string id)
        {
            if (this.id != id) return;
            OnFinished();
        }

        void RemoveListeners()
        {
            if (!miniGame) return;

            miniGame.finished -= OnFinished;
            miniGame.close -= RemoveListeners;
        }

        public void Repair()
        {
            sprite.sprite = settings.repairedSprite;
            GetComponent<Interactable.Interactable>().Remove();
            if (miniGame)
                Destroy(miniGame.gameObject);
            isFinished = true;
            Destroy(this);

            if (MiniGame.count <= 0)
                Network.Event.instance.GameOver();
        }

        void OnDestroy()
        {
            Network.Event.questRepaired -= OnFinished;
        }
    }
}
