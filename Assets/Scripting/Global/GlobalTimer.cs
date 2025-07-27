using TMPro;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    [Header("Настройки таймера")]
    [SerializeField] private float _timerDuration = 10f; // Длительность таймера в секундах
    [SerializeField] private TMP_Text _timerText; // Ссылка на текстовый элемент TMP

    private float _currentTime;
    private bool _isRunning;
    private bool _isPaused;

    private void Start()
    {
        // Подписываемся на событие обновления времени
        OnTimeUpdated += UpdateTimerDisplay;
    }

    private void OnDestroy()
    {
        // Отписываемся при уничтожении объекта
        OnTimeUpdated -= UpdateTimerDisplay;
    }

    // Событие для обновления времени
    public event System.Action<float> OnTimeUpdated;

    // Метод для обновления отображения таймера
    private void UpdateTimerDisplay(float time)
    {
        if (_timerText != null)
        {
            // Форматируем время в минуты:секунды
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Альтернативный вариант - просто секунды с двумя знаками после запятой
            // _timerText.text = time.ToString("F2");
        }
    }

    // Метод 1: Запуск таймера
    public void StartTimer()
    {
        _currentTime = _timerDuration;
        _isRunning = true;
        _isPaused = false;
        UpdateTimerDisplay(_currentTime); // Обновляем отображение сразу при старте
    }

    // Метод 2: Получение текущего значения таймера
    public float GetCurrentTime()
    {
        return _currentTime;
    }

    // Метод 3: Пауза таймера
    public void PauseTimer()
    {
        if (_isRunning && !_isPaused)
        {
            _isPaused = true;
        }
    }

    // Метод продолжения таймера
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
