using UnityEngine;
using UnityEngine.Events;

public class MiniGamePanel : MonoBehaviour
{
    public UnityEvent<int> OnSolve;
    protected bool _isOpened = false;

    public void TogglePanel(bool enabled)
    {
        _isOpened = enabled;
        gameObject.SetActive(enabled);
    }
    protected void onSovled(BreakAble breaked)
    {
        breaked.ChangeBreaked(false);
        TogglePanel(false);
        OnSolve.RemoveAllListeners();
    }
    public virtual void Activate(BreakAble breaked)
    {
        OnSolve.AddListener(c => onSovled(breaked));
        TogglePanel(true);
    }
}
