using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class RotatorsPanel : MonoBehaviour
{
    [SerializeField] private List<Rotator> rotators = new();
    private bool _isOpened = false;
    public UnityEvent OnAllSolve;

    private void Start()
    {
        _isOpened = false;
        gameObject.SetActive(false);
    }

    public void TogglePanel()
    {
        _isOpened = !_isOpened;
        gameObject.SetActive(_isOpened);
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