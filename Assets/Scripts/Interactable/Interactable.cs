using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Interactable
{
    [RequireComponent(typeof(Collider2D))]
    public class Interactable : MonoBehaviour
    {
        public Vector2 position = new Vector2(2.5f, 0.75f);
        public Vector2 size = new Vector2(3, 1);
        public LayerMask mask;

        [System.Serializable]
        public struct Action
        {
            [TextArea]
            public string text;
            public UnityEngine.Events.UnityEvent OnConfirmed;
        }
        public Action[] actions;

        private Collider2D trigger;
        private VerticalLayoutGroup canvas;
        private RectTransform rect;
        private Player.Inputs inputActions;
        private List<TextField> fields = new List<TextField>();

        private bool Active
        {
            get => canvas.gameObject.activeInHierarchy;
            set => canvas.gameObject.SetActive(value);
        }

        private int Selected
        {
            get
            {
                for (int i = 0; i < fields.Count; i++)
                    if (fields[i].Selected) return i;
                return -1;
            }
            set
            {
                if (fields.Count < 1) return;
                if (value < 0) value = fields.Count - 1;
                var selectedIndex = value % fields.Count;
                for (int i = 0; i < fields.Count; i++)
                    fields[i].Selected = selectedIndex == i;
            }
        }

        public void Remove()
        {
            foreach (var field in fields)
            {
                Destroy(field.gameObject);
            }

            inputActions.Disable();
            Destroy(this);
            Destroy(GetComponent<Collider2D>());
        }

        private void Awake()
        {
            var container = new GameObject("Fields");

            canvas = container.AddComponent<VerticalLayoutGroup>();
            rect = container.GetComponent<RectTransform>();
            canvas.transform.SetParent(transform);

            rect.localPosition = position;
            rect.sizeDelta = size;
            inputActions = new Player.Inputs();

            trigger = GetComponent<Collider2D>();
            trigger.isTrigger = true;

            inputActions.Interactions.Use.performed += _ => Select();
            inputActions.Interactions.Scroll.performed += OnScroll;
        }

        private void Start()
        {
            Active = true;
            foreach (var action in actions)
                AddField(action.text, () => action.OnConfirmed?.Invoke());

            Active = false;
        }

        private void OnScroll(InputAction.CallbackContext ctx)
        {
            var value = (int)ctx.ReadValue<float>();
            Selected += value;
        }

        private void Select()
        {
            var field = fields[Selected];
            if (field) field.Trigger();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var inMask = mask == (mask | (1 << collider.gameObject.layer));
            if (
                !collider.GetComponent<Player.Script>().photonView.IsMine ||
                !inMask
            )
                return;

            Selected = fields.Count / 2;
            inputActions.Enable();
            Active = true;
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            Active = false;
            inputActions.Disable();
        }

        public void AddField(string text, TextField.OnConfirmed callback)
        {
            var container = new GameObject($"Field ({text})");
            container.transform.SetParent(canvas.transform);
            var field = container.AddComponent<TextField>();
            field.Text = text;

            fields.Add(field);
            field.confirmed += callback;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position + (Vector3)position, size);
        }
    }
}