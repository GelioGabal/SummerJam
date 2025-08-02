using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D _rb;
    CharacterController character;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (InputManager.playerInput.Player.Move.IsPressed())
        {
            character.GetAnimator.SetBool("IsWalking", true);
            float direction = InputManager.playerInput.Player.Move.ReadValue<Vector2>().x;
            transform.localScale = new(direction < 0 ? -1 : 1, 1);
            _rb.linearVelocity = new Vector2(direction * Time.fixedDeltaTime * moveSpeed * 100f, _rb.linearVelocityY);
        }
        else
        {
            character.GetAnimator.SetBool("IsWalking", false);
            _rb.linearVelocity = Vector2.zero;
        }
    }
}
