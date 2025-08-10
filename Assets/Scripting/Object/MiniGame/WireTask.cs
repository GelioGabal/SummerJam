using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WireTask : MiniGamePanel
{
    [SerializeField] float magnetRadius;
    [SerializeField] List<Wire> leftWires = new ();
    [SerializeField] List<Wire> rightWires = new ();
    [SerializeField] List<Color> wireColors = new ();
    List<Wire> allWires;
    protected override void Randomize()
    {
        allWires = leftWires.Concat(rightWires).ToList();
        var numbers = Enumerable.Range(0, wireColors.Count()).ToList();
        var left = numbers.OrderBy(x => new System.Random().Next()).ToList();
        var right = numbers.OrderBy(x => new System.Random().Next()).ToList();

        for (int i = 0; i < wireColors.Count(); i++)
        {
            leftWires[i].Initialize(this, rightWires[right.FindIndex(c => c == left[i])], wireColors[left[i]], magnetRadius);
            rightWires[i].Initialize(this, leftWires[left.FindIndex(c => c == right[i])], wireColors[right[i]], magnetRadius);
        }
    }
    public override void CheckAllSolved()
    {
        if (allWires.All(w => w.isSolved)) OnSolve.Invoke(0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(var w in leftWires)
            Gizmos.DrawWireSphere(w.transform.position, magnetRadius);
        foreach(var w in rightWires)
            Gizmos.DrawWireSphere(w.transform.position, magnetRadius);
    }
}
