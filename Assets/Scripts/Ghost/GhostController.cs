using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private Human.Inputs inputs;
        [SerializeField] private float moveSpeed = 4f;

        private Rigidbody2D body;

        private void Awake()
        {
            inputs = new Human.Inputs();
            inputs.Enable();
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.velocity = (Vector3)inputs.Movements.Move.ReadValue<Vector2>() * moveSpeed;
        }

        private void OnEnable() => inputs.Enable();
        private void OnDisable() => inputs.Disable();
    }
}