using TMPro;
using UnityEngine;
using UnityEngine.Events;
public enum TimerState
{
    Running,
    FirstPause,
    SecondPause,
    ThirdPause,
    Finished
}
public class GlobalTimer : MonoBehaviour
{
    [Header("Настройки таймера")]
    [SerializeField] private float _timerDuration = 10f; 
    [SerializeField] private TMP_Text _timerText;


    [Header("Настройки пауз")]
    [SerializeField] private float _firstPauseAt;
    [SerializeField] private float _secondPauseAt;
    [SerializeField] private float _thirdPauseAt;


    [Header("События")]
    public UnityEvent OnFirstPause;
    public UnityEvent OnSecondPause;
    public UnityEvent OnThirdPause;
    public UnityEvent OnTimerFinished;

    private double deep = 1;
    private float _currentTime;
    private bool _isRunning;
    private TimerState _currentState;
    private bool _hasFirstPauseTriggered = false;
    private bool _hasSecondPauseTriggered = false;
    private bool _hasThirdPauseTriggered = false;


    private void Start()
    {
        OnTimeUpdated += UpdateTimerDisplay;
    }

    private void OnDestroy()
    {
        OnTimeUpdated -= UpdateTimerDisplay;
    }

    public event System.Action<float> OnTimeUpdated;

    private void UpdateTimerDisplay(float time)
    {
        if (_timerText != null)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        _currentTime = _timerDuration;
        _isRunning = true;
        _currentState = TimerState.Running;
        _hasFirstPauseTriggered = false;
        _hasSecondPauseTriggered = false;
        _hasThirdPauseTriggered = false;
        UpdateTimerDisplay(_currentTime);
    }

    public void ResetToInitialState()
    {
        StartTimer();
        ContinueTimer();
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }

    public void PauseTimer()
    {
        _isRunning = false;
    }

    public void ContinueTimer()
    {
        _isRunning = true;
    }

    public TimerState GetCurrentState()
    {
        return _currentState;
    }

    private void CheckForPauses()
    {
        if (!_hasFirstPauseTriggered && _currentTime <= _firstPauseAt)
        {
            _currentState = TimerState.FirstPause;
            PauseTimer();
            OnFirstPause?.Invoke();
            _hasFirstPauseTriggered = true;
            return;
        }

        if (!_hasSecondPauseTriggered && _currentTime <= _secondPauseAt)
        {
            _currentState = TimerState.SecondPause;
            PauseTimer();
            OnSecondPause?.Invoke();
            _hasSecondPauseTriggered = true;
            return;
        }

        if (!_hasThirdPauseTriggered && _currentTime <= _thirdPauseAt)
        {
            _currentState = TimerState.ThirdPause;
            PauseTimer();
            OnThirdPause?.Invoke();
            _hasThirdPauseTriggered = true;
            return;
        }
    }

    private void Update()
    {
        if (!_isRunning)
            return;

        _currentTime -= Time.deltaTime;
        deep += 0.1;
        OnTimeUpdated?.Invoke(_currentTime);

        CheckForPauses();

        if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            _isRunning = false;
            _currentState = TimerState.Finished;
            OnTimeUpdated?.Invoke(_currentTime);
            OnTimerFinished?.Invoke();
        }
    }

    public double GetDeep()
    {
        return deep;
    }
}
