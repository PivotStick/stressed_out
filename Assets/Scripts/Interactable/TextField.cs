using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Interactable
{
    public class TextField : MonoBehaviour
    {
        private TextMeshPro text;
        private bool selected;
        private float fontSize;

        public bool Selected
        {
            get => selected;
            set
            {
                selected = value;
                text.fontWeight = selected ? FontWeight.Bold : FontWeight.Regular;
                fontSize = selected ? 3 : 2;
            }
        }

        public string Text
        {
            get => text.text;
            set => text.SetText(value);
        }

        public delegate void OnConfirmed();
        public event OnConfirmed confirmed;

        private void FixedUpdate()
        {
            text.fontSize += (fontSize - text.fontSize) * 0.2f;
        }

        private void Awake()
        {
            text = gameObject.AddComponent<TextMeshPro>();

            text.verticalAlignment = VerticalAlignmentOptions.Middle;
            text.fontSize = 1;
            Selected = false;
        }

        public void Trigger()
        {
            confirmed?.Invoke();
        }
    }
}