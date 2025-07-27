using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class RotatorsPanel : MiniGamePanel
{
    [SerializeField] private List<Rotator> rotators = new();
    public UnityEvent<int> OnAllSolve;
    private void Start()
    {
        ClosePanel();
    }
    public void RandomizeAllRotators()
    {
        foreach (var rotator in rotators.Where(rotator => rotator != null))
        {
            rotator.RotateToRandomAngle();
        }
    }

    public void CheckAllSolved()
    {
        if (rotators.Count == 0)
        {
            Debug.LogWarning("Список ротаторов пуст!");
            return;
        }

        if (rotators.Any(rotator => rotator == null || !rotator.IsSolved))
        {
            return;
        }

        Debug.Log("Все головоломки решены!");
        OnAllSolve?.Invoke(0);
    }

    public void AddRotator(Rotator newRotator)
    {
        if (!rotators.Contains(newRotator))
        {
            rotators.Add(newRotator);
        }
    }
    public void EnableRotators(BreakAble breaked)
    {
        RandomizeAllRotators();
        OnAllSolve.AddListener(c => onSovled(breaked));
        TogglePanel();
    }
    void onSovled(BreakAble breaked)
    {
        breaked.ChangeBreaked(false);
        ClosePanel();
        OnAllSolve.RemoveAllListeners();
    }
}