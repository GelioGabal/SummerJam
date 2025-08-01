using UnityEngine;
using UnityEngine.Events;

public class BreakAble : MonoBehaviour
{
    [SerializeField] int RepairCost = 1;
    [SerializeField] bool doFlood = false;
    [SerializeField] Flooding flooding;
    public UnityEvent OnBreak = new();
    public UnityEvent OnFix = new();
    public bool IsBreaked { get; private set; } = false;
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
        if (doFlood) flooding.ChangeBreaked(breaked ? 1 : -1);
        if (IsBreaked) OnBreak.Invoke();
        else OnFix.Invoke();
        PlayerInteractor.UpdateInteraction.Invoke();
        Debug.Log($"Breaked {breaked}");
    }
    protected virtual void Break()
    {
        reparer.enabled = true;
    }
    protected virtual void Fix()
    {
        reparer.enabled = false;
        BrokeManager.OnFixBroke.Invoke();
    }
}
