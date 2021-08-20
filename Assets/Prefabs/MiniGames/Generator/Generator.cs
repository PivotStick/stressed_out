using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace MiniGames
{
    public class Generator : Quest.MiniGame
    {
        public Button[] buttons;

        public AudioClip audioSuccess;
        public AudioClip audioFail;
        public AudioClip audioClick;

        private int currentNumber = 0;

        override protected void Awake()
        {
            base.Awake();

            var texts = new List<TMP_Text>();

            foreach (var button in buttons)
            {
                button.onClick.AddListener(() => OnClick(button));
                texts.Add(button.GetComponentInChildren<TMP_Text>());
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                var index = UnityEngine.Random.Range(0, texts.Count);
                texts[index].text = (i + 1).ToString();
                texts.RemoveAt(index);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            close += ResetMiniGame;
        }

        IEnumerator Fail()
        {
            gameAudio.clip = audioFail;
            gameAudio.Play();

            foreach (var button in buttons)
            {
                button.enabled = false;
                button.GetComponent<Image>().color = Color.red;
            }

            yield return new WaitForSeconds(1);

            ResetMiniGame();
        }

        void ResetMiniGame()
        {
            currentNumber = 0;

            foreach (var button in buttons)
            {
                button.GetComponent<Image>().color = Color.white;
                button.enabled = true;
            }
        }

        IEnumerator Success()
        {
            gameAudio.clip = audioSuccess;
            gameAudio.Play();
            yield return new WaitForSeconds(2);
            Finish();
        }

        void OnClick(Button button)
        {
            gameAudio.clip = audioClick;
            gameAudio.Play();

            var number = Int32.Parse(button.GetComponentInChildren<TMP_Text>().text);

            if (number != currentNumber + 1)
            {
                StartCoroutine(Fail());
                return;
            }

            button.GetComponent<Image>().color = Color.green;
            button.enabled = false;
            currentNumber++;

            if (currentNumber >= buttons.Length)
            {
                StartCoroutine(Success());
            }
        }
    }
}