using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class RotatorsPanel : MiniGamePanel
{
    [SerializeField] private List<Rotator> rotators = new();
    public UnityEvent OnAllSolve;

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
        OnAllSolve?.Invoke();
    }

    public void AddRotator(Rotator newRotator)
    {
        if (!rotators.Contains(newRotator))
        {
            rotators.Add(newRotator);
        }
    }
}