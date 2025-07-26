using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class RotatorsPanel : MonoBehaviour
{
    [SerializeField] private List<Rotator> rotators = new();
    public UnityEvent OnAllSolve;

    private void Awake()
    {
        OnAllSolve.AddListener(() =>
        {
            Debug.Log("Всё решено, закрываем панель");
            gameObject.SetActive(false);
        });
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    // private void SetRotators()
    // {
    //     rotators.Clear();
    //
    //     var childRotators = GetComponentsInChildren<Rotator>();
    //     foreach (var rotator in childRotators)
    //     {
    //         if (!rotators.Contains(rotator))
    //         {
    //             rotators.Add(rotator);
    //         }
    //     }
    // }

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
        gameObject.SetActive(false);
    }

    public void AddRotator(Rotator newRotator)
    {
        if (!rotators.Contains(newRotator))
        {
            rotators.Add(newRotator);
        }
    }
}