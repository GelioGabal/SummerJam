using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private GameObject tooltip;
    public UnityEvent OnInteract = new();
    
    private void Start()
    {
        if (tooltip != null)
            tooltip.SetActive(false);
    }
    
    public void ShowTooltip(bool show)
    {
        if (tooltip == null) return;
        
        tooltip.SetActive(show);
        Debug.Log("Показываем подсказку: " + show);
    }
}