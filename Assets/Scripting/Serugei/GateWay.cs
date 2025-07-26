using UnityEngine;
using UnityEngine.Events;

public class GateWay : MonoBehaviour
{
    public bool isOpen;
    public UnityEvent OnInteract = new();
    //public bool isOpen {  get; private set; }
    public void Interact()
    {
        isOpen = !isOpen;
        OnInteract.Invoke();
    }
}
