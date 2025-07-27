using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    InteractiveObject curInteract;
    void Start()
    {
        InputManager.playerInput.Object.Interact.performed += Interact;
    }
    private void OnDisable()
    {
        InputManager.playerInput.Object.Interact.performed -= Interact;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out curInteract)) 
            curInteract.ShowTooltip(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out InteractiveObject obj))
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
