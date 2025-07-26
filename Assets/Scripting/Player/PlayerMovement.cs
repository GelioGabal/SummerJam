using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private bool _isMoving;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        InputManager.input.Player.Move.performed += OnMove;
        InputManager.input.Player.Move.canceled += OnMove;
        InputManager.input.Player.Enable();
    }

    private void OnDisable()
    {
        InputManager.input.Player.Move.performed -= OnMove;
        InputManager.input.Player.Move.canceled -= OnMove;
        InputManager.input.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.linearVelocity = _moveInput * moveSpeed;
    }
}
