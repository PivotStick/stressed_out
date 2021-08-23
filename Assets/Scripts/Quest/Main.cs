using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class Main : MonoBehaviour
    {
        public Settings settings;
        private MiniGame miniGame;
        private bool isFinished = false;
        public bool IsFinished { get => isFinished; }

        private SpriteRenderer sprite;

        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = settings.brokenSprite;
        }

        public void OpenQuest()
        {
            if (isFinished) return;
            if (!miniGame)
                miniGame = Instantiate(settings.miniGame);

            miniGame.Visible = true;
            miniGame.finished += OnFinished;
            miniGame.close += RemoveListeners;
        }

        void OnFinished()
        {
            RemoveListeners();
            Repair();
        }

        void RemoveListeners()
        {
            miniGame.finished -= OnFinished;
            miniGame.close -= RemoveListeners;
        }

        public void Repair()
        {
            sprite.sprite = settings.repairedSprite;
            GetComponent<Interactable.Interactable>().Remove();
            Destroy(miniGame.gameObject);
            isFinished = true;
            Destroy(this);
        }
    }
}
