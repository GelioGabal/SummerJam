using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TimerPhase
{
    FirstPhase,
    SecondPhase,
    ThirdPhase,
    Defoult
}
public class FlexibleTimer : MonoBehaviour
{

    private float _currentTime;
    private float _duration;
    private bool _isRunning;


    public UnityEvent<float> OnTimeUpdated;
    public UnityEvent OnTimerStarted;
    public UnityEvent OnTimerFinished;


    public void StartTimer(float duration)
    {
        _duration = duration;
        _currentTime = duration;
        _isRunning = true;
        OnTimerStarted?.Invoke();
    }


    public void StopTimer()
    {
        _isRunning = false;
    }


    public void ResetTimer()
    {
        _currentTime = _duration;
        _isRunning = false;
    }


    public float GetCurrentTime()
    {
        return _currentTime;
    }


    public bool IsRunning()
    {
        return _isRunning;
    }



    private void Update()
    {
        if (!_isRunning) return;

        _currentTime -= Time.deltaTime;
        OnTimeUpdated?.Invoke(_currentTime);

        if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            _isRunning = false;
            OnTimerFinished?.Invoke();
        }
    }

    public void SetDuration(float newDuration)
    {
        _duration = newDuration;
        ResetTimer();
    }

}  

