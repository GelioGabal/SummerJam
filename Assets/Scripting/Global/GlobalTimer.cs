using TMPro;
using UnityEngine;
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

    private double deep = 1;

    private float _currentTime;
    private bool _isRunning;
    private bool _isPaused;

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
        _isPaused = false;
        UpdateTimerDisplay(_currentTime); 
    }


    public float GetCurrentTime()
    {
        return _currentTime;
    }

    public void PauseTimer()
    {
        if (_isRunning && !_isPaused)
        {
            _isPaused = true;
        }
    }


    public void ContinueTimer()
    {
        if (_isRunning && _isPaused)
        {
            _isPaused = false;
        }
    }

    private void Update()
    {
        if (!_isRunning || _isPaused)
            return;

        _currentTime -= Time.deltaTime;
        deep += 0.1;
        OnTimeUpdated?.Invoke(_currentTime);

        if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            _isRunning = false;
            OnTimeUpdated?.Invoke(_currentTime); 
        }
    }

    public double getDeep()
    {
        return deep;
    }
}
