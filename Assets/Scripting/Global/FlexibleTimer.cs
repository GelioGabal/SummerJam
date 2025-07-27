using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public enum TimerState
{
    Running,       
    FirstPause,    
    SecondPause,  
    ThirdPause,    
    Finished     
}

public class FlexibleTimer : MonoBehaviour
{

    
    [Header("Настройки пауз")]
    [SerializeField] private float _firstPauseAt;
    [SerializeField] private float _secondPauseAt;
    [SerializeField] private float _thirdPauseAt;



    private float _currentTime;
    private float _duration;
    private TimerState _currentState;
    private float _pauseTimeRemaining; // Сохраняет оставшееся время при паузе

    [Header("События")]
    public UnityEvent<float> OnTimeUpdated;
    public UnityEvent OnTimerStarted;
    public UnityEvent OnTimerFinished;
    public UnityEvent OnFirstPauseReached;
    public UnityEvent OnSecondPauseReached;
    public UnityEvent OnThirdPauseReached;
    public UnityEvent OnTimerContinued;

    public TimerState CurrentState => _currentState;
    public float CurrentTime => _currentState == TimerState.Running ? _currentTime : _pauseTimeRemaining;


    bool _firstPause;
   bool _secondPause;  
    bool _thirdPause;
    public void StartTimer(float duration)
    {
        _duration = duration;
        _currentTime = duration;
        _pauseTimeRemaining = duration;
        _currentState = TimerState.Running;
        OnTimerStarted?.Invoke();
        _firstPause = false;
        _secondPause = false;
        _thirdPause = false;
    }

    public void setFirstSattion()
    {
        _firstPause = true;
    }
    public void setSecondSattion()
    {
        _secondPause=true;
    }
    public void setthirdSattion()
    {
        _thirdPause = true;
    }

    public void ContinueTimer()
    {
        if (_currentState != TimerState.Running && _currentState != TimerState.Finished)
        {
            StartTimer(_pauseTimeRemaining);
            _currentTime = _pauseTimeRemaining;
            _currentState = TimerState.Running;
            
            OnTimerContinued?.Invoke();
        }
    }

    private void Update()
    {
        switch (_currentState)
        {
            case TimerState.Running:
                UpdateRunningState();
                break;

            case TimerState.FirstPause:
            case TimerState.SecondPause:
            case TimerState.ThirdPause:
                _pauseTimeRemaining = _currentTime;
                break;

            case TimerState.Finished:
                break;
        }
    }

    private void UpdateRunningState()
    {
        _currentTime -= Time.deltaTime;
        OnTimeUpdated?.Invoke(_currentTime);

        if (_currentTime <= _firstPauseAt && _currentTime > _secondPauseAt && _currentState != TimerState.FirstPause)
        {
            SetPauseState(TimerState.FirstPause, OnFirstPauseReached);
        }
        else if (_currentTime <= _secondPauseAt && _currentTime > _thirdPauseAt && _currentState != TimerState.SecondPause)
        {
            SetPauseState(TimerState.SecondPause, OnSecondPauseReached);
        }
        else if (_currentTime <= _thirdPauseAt && _currentTime > 0 && _currentState != TimerState.ThirdPause)
        {
            SetPauseState(TimerState.ThirdPause, OnThirdPauseReached);
        }
        else if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            _currentState = TimerState.Finished;
            OnTimerFinished?.Invoke();
        }
    }

    private void SetPauseState(TimerState state, UnityEvent pauseEvent)
    {
        _currentState = state;
        _pauseTimeRemaining = _currentTime; 

        pauseEvent?.Invoke();
    }
}

