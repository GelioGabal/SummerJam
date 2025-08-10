using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RotatorsPanel : MiniGamePanel
{
    [SerializeField] private List<Transform> rotators = new();
    protected override void Randomize()
    {
        foreach (var rotator in rotators)
            rotator.localEulerAngles = new Vector3(0, 0, 45f * Random.Range(1, 7));
    }
    public override void CheckAllSolved()
    {
        if (rotators.All(rotator => checkSolved(rotator))) OnSolve?.Invoke(0);
    }
    bool checkSolved(Transform target)
    {
        return target.localRotation.z <= 0;
    }
    public void Rotate(Transform target)
    {
        if (checkSolved(target)) return;
        target.localEulerAngles = new Vector3(0, 0, target.localEulerAngles.z + 45f);
        CheckAllSolved();
    }
}