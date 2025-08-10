using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioSource stepsSource;
    [SerializeField] AudioClip normalStepsSound, lowWaterStepsSound, mediumWaterStepsSound, hightWaterStepsSound;
    Rigidbody2D rb;
    CharacterController character;
    Vector2 lastPos;
    private void Awake()
    {
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
        lastPos = (Vector2)transform.position;
    }
    private void FixedUpdate()
    {
        if (InputManager.playerInput.Player.Move.IsPressed())
        {
            float direction = InputManager.playerInput.Player.Move.ReadValue<Vector2>().x;
            transform.localScale = new(direction < 0 ? -1 : 1, 1);
            rb.linearVelocity = new Vector2(direction * Time.fixedDeltaTime * moveSpeed * 100f, rb.linearVelocityY);
            bool animate = lastPos != (Vector2)transform.position;
            stepsSource.volume = animate ? 1 : 0;
            character.GetAnimator.SetBool("IsWalking", animate);
            lastPos = (Vector2)transform.position;
        }
        else
        {
            character.GetAnimator.SetBool("IsWalking", false);
            rb.linearVelocity = Vector2.zero;
            stepsSource.volume = 0;
        }
    }
}
