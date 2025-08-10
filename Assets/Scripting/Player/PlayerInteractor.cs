using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public static UnityEvent UpdateInteraction = new();
    InteractiveObject curInteract;
    void Start()
    {
        InputManager.playerInput.Player.Interact.performed += Interact;
        UpdateInteraction.AddListener(updateInteraction);
    }
    void updateInteraction()
    {
        if (curInteract == null || curInteract.enabled) return;
        curInteract.ShowTooltip(false);
        curInteract = null;
    }
    private void OnDisable()
    {
        InputManager.playerInput.Player.Interact.performed -= Interact;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out InteractiveObject obj) && obj.enabled)
        {
            curInteract = obj;
            curInteract.ShowTooltip(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out InteractiveObject obj) && obj.enabled)
        {
            if (obj != curInteract) return;
            curInteract.ShowTooltip(false);
            curInteract = null;
        }
    }
    void Interact(InputAction.CallbackContext ctx)
    {
        curInteract?.OnInteract.Invoke();
    }
}
