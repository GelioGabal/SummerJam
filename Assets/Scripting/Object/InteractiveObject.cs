using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] string tooltipText;
    [SerializeField] private TMP_Text tooltip;
    public UnityEvent OnInteract = new();
    
    private void Start()
    {
        if (tooltip != null)
            tooltip.gameObject.SetActive(false);
        OnInteract.AddListener(playSound);
    }
    
    public void ShowTooltip(bool show)
    {
        if (tooltip == null) return;
        
        if (show)
            tooltip.text = tooltipText;
        tooltip.gameObject.SetActive(show);
    }
    void playSound() { if (sound != null) SoundPlayer.Play.Invoke(sound); }
}