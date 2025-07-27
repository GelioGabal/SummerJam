using UnityEngine;
using UnityEngine.Events;

public class BreakAble : MonoBehaviour
{
    [SerializeField] int RepairCost = 1;
    [SerializeField] Flooding flooding;
    public UnityEvent OnBreak = new();
    public UnityEvent OnFix = new();
    bool IsBreaked = false;
    InteractiveObject reparer;
    protected virtual void Start()
    {
        reparer = GetComponent<InteractiveObject>();
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
    protected virtual void Break()
    {
        reparer.enabled = true;
    }
    protected virtual void Fix()
    {
        reparer.enabled = false;
    }
}
