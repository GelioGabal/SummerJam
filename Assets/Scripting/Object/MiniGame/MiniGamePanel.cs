using UnityEngine;
using UnityEngine.Events;

public abstract class MiniGamePanel : MonoBehaviour
{
    public UnityEvent<int> OnSolve;
    protected bool _isOpened = false;

    protected abstract void Randomize();
    public abstract void CheckAllSolved();
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
        Randomize();
        OnSolve.AddListener(c => onSovled(breaked));
        TogglePanel(true);
    }
}
