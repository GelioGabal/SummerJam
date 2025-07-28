using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PumpController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static UnityEvent<string, bool> OnTogglePump = new();
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTogglePump.Invoke(gameObject.name, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnTogglePump.Invoke(gameObject.name, false);
    }
}
