using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class LoseManager : MonoBehaviour
{
    [SerializeField] List<Flooding> floodings;
    [SerializeField][Range(0,1f)] float maxAverageFlooding;
    [SerializeField] float timeToLose;
    [SerializeField] GameObject warning, loseWindow;
    [SerializeField] Engine engine;
    bool isLoosing = false;
    Coroutine coroutine;
    void Start()
    {
        Flooding.OnChangeLevel.AddListener(checkCondition);
    }
    void checkCondition(string s,float f)
    {
        float commonAverage = floodings.Average(f => f.FloodingPercent);
        engine.Down(commonAverage);
        isLoosing = commonAverage >= maxAverageFlooding;
        warning.SetActive(isLoosing);
        toggle(isLoosing);
    }
    void toggle(bool enable)
    {
        if (!enable && coroutine != null) StopCoroutine(coroutine);
        else if (enable && coroutine == null) coroutine = StartCoroutine(timer(timeToLose));
    }
    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        lose();
    }
    void lose()
    {
        InputManager.playerInput.Disable();
        loseWindow.SetActive(true);
    }
}
