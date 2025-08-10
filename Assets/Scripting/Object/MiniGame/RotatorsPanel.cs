using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RotatorsPanel : MiniGamePanel
{
    [SerializeField] private List<Transform> rotators = new();
    void checkAllSolved()
    {
        if (rotators.All(rotator => checkSolved(rotator))) OnSolve?.Invoke(0);
    }
    public override void Activate(BreakAble breaked)
    {
        foreach (var rotator in rotators)
            RotateToRandomAngle(rotator);
        base.Activate(breaked);
    }
    public void RotateToRandomAngle(Transform target)
    {
        target.localEulerAngles = new Vector3(0, 0, 45f * Random.Range(1, 7));
    }
    public void Rotate(Transform target)
    {
        if (checkSolved(target)) return;
        target.localEulerAngles = new Vector3(0, 0, target.localEulerAngles.z + 45f);
        checkAllSolved();
    }
    bool checkSolved(Transform target)
    {
        return target.localRotation.z <= 0;
    }
}