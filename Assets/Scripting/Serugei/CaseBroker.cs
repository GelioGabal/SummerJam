using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CaseBroker : BreakAble
{
    [SerializeField] List<Vector2> breakPoints;
    [SerializeField] float gizmosSize;
    List<int> currentBreakPoints = new();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var point in breakPoints)
            Gizmos.DrawCube(point, Vector2.one * gizmosSize);
    }
    void addBreak()
    {
        int id = 0;
        do id = Random.Range(0, breakPoints.Count);
        while (currentBreakPoints.Contains(id));
    }
}
