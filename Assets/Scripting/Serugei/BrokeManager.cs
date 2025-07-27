using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BrokeManager : MonoBehaviour
{
    public static UnityEvent OnFixBroke = new();
    [SerializeField] List<BreakAble> breakAbles = new();
    [SerializeField] int maxBroked = 1;
    [SerializeField] float timeBetweenBroke = 10;
    private void Start()
    {
        s();
        OnFixBroke.AddListener(s);
    }
    void s()
    {
        StopAllCoroutines();
        StartCoroutine(t());
    }
    IEnumerator t()
    {
        yield return new WaitForSeconds(timeBetweenBroke);
        if (breakAbles.Count(br => br.IsBreaked) < maxBroked)
            breakAbles[Random.Range(0,breakAbles.Count)].ChangeBreaked(enabled);
    }
}
