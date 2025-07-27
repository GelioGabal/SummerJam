using UnityEngine;

using UnityEngine.Events;
using UnityEngine.InputSystem;
public class MiniGamesOpener : InteractiveObject
{
    // [SerializeField] private GameObject tooltip;
    private bool _isPlayerInTriggerZone;
    
    // public UnityEvent OnInteract;
    public UnityEvent OnLeaveZone;

    private void Awake()
    {
        OnInteract.AddListener(() => 
        {
            Debug.Log("OnInteract вызвано");
        });
        
        OnInteract.AddListener(() => 
        {
            Debug.Log("Скроем подсказочку");
            ShowTooltip(false);
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        InputManager.playerInput.Object.Interact.performed += Interact;
        InputManager.playerInput.Object.Enable();
        
        _isPlayerInTriggerZone = true;
        ShowTooltip(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        InputManager.playerInput.Object.Interact.performed -= Interact;
        InputManager.playerInput.Object.Disable();
        
        _isPlayerInTriggerZone = false;
        ShowTooltip(false);
        
        OnLeaveZone?.Invoke();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (!_isPlayerInTriggerZone) return;

        Debug.Log("Игрок в зоне взаимодейсвия нажал на кнопку взаимодейсвтия");
        OnInteract?.Invoke();
    }
}