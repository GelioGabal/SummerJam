using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent OnDown = new();
    [SerializeField] UnityEvent OnUp = new();

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp.Invoke();
    }
}
