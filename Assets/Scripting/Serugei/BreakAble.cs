using UnityEngine;
using UnityEngine.Events;

public abstract class BreakAble : MonoBehaviour
{
    [SerializeField] int RepairCost = 1;
    [SerializeField] Flooding flooding;
    public UnityEvent OnBreak = new();
    public UnityEvent OnFix = new();
    bool IsBreaked = false;
    private void Start()
    {
        OnBreak.AddListener(Break);
        OnFix.AddListener(Fix);
    }
    public void ChangeBreaked(bool breaked)
    {
        IsBreaked = breaked;
        flooding.ChangeBreaked(breaked ? 1 : -1);
        if (IsBreaked) OnBreak.Invoke();
        else OnFix.Invoke();
    }
    protected abstract void Break();
    protected abstract void Fix();
}
