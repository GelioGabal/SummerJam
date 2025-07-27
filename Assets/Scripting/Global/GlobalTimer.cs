using TMPro;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    [Header("��������� �������")]
    [SerializeField] private float _timerDuration = 10f; // ������������ ������� � ��������
    [SerializeField] private TMP_Text _timerText; // ������ �� ��������� ������� TMP

    private float _currentTime;
    private bool _isRunning;
    private bool _isPaused;

    private void Start()
    {
        // ������������� �� ������� ���������� �������
        OnTimeUpdated += UpdateTimerDisplay;
    }

    private void OnDestroy()
    {
        // ������������ ��� ����������� �������
        OnTimeUpdated -= UpdateTimerDisplay;
    }

    // ������� ��� ���������� �������
    public event System.Action<float> OnTimeUpdated;

    // ����� ��� ���������� ����������� �������
    private void UpdateTimerDisplay(float time)
    {
        if (_timerText != null)
        {
            // ����������� ����� � ������:�������
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // �������������� ������� - ������ ������� � ����� ������� ����� �������
            // _timerText.text = time.ToString("F2");
        }
    }

    // ����� 1: ������ �������
    public void StartTimer()
    {
        _currentTime = _timerDuration;
        _isRunning = true;
        _isPaused = false;
        UpdateTimerDisplay(_currentTime); // ��������� ����������� ����� ��� ������
    }

    // ����� 2: ��������� �������� �������� �������
    public float GetCurrentTime()
    {
        return _currentTime;
    }

    // ����� 3: ����� �������
    public void PauseTimer()
    {
        if (_isRunning && !_isPaused)
        {
            _isPaused = true;
        }
    }

    // ����� ����������� �������
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
        OnTimeUpdated?.Invoke(_currentTime);

        if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            _isRunning = false;
            OnTimeUpdated?.Invoke(_currentTime); 
        }
    }
}
