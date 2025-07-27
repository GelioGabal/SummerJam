using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("UI элементы")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _stateText;

    [Header("Настройки")]
    [SerializeField] private string _timeFormat = "mm':'ss";
    [SerializeField] private string _finishMessage = "Время вышло!";

    private FlexibleTimer _timer;

    private void Awake()
    {
        Debug.Log("Game.Awake()");
        _timer = GetComponent<FlexibleTimer>();
        _timer.StartTimer(20);
    }

    public void StartGame(int durationInSeconds)
    {
        Debug.Log($"Запуск таймера на {durationInSeconds} секунд");
        _timer.StartTimer(durationInSeconds);
    }

    private void OnEnable()
    {
        Debug.Log("Подписка на события таймера");
        _timer.OnTimeUpdated.AddListener(UpdateTimerUI);
        _timer.OnTimerStarted.AddListener(OnTimerStart);
        _timer.OnTimerFinished.AddListener(OnTimerFinish);
        _timer.OnFirstPauseReached.AddListener(OnFirstPause);
        _timer.OnSecondPauseReached.AddListener(OnSecondPause);
        _timer.OnThirdPauseReached.AddListener(OnThirdPause);
        _timer.OnTimerContinued.AddListener(OnContinue);
    }

    private void OnDisable()
    {
        _timer.OnTimeUpdated.RemoveListener(UpdateTimerUI);
        _timer.OnTimerStarted.RemoveListener(OnTimerStart);
        _timer.OnTimerFinished.RemoveListener(OnTimerFinish);
        _timer.OnFirstPauseReached.RemoveListener(OnFirstPause);
        _timer.OnSecondPauseReached.RemoveListener(OnSecondPause);
        _timer.OnThirdPauseReached.RemoveListener(OnThirdPause);
        _timer.OnTimerContinued.RemoveListener(OnContinue);
    }

    private void UpdateTimerUI(float timeLeft)
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeLeft);
        _timerText.text = timeSpan.ToString(_timeFormat);
        Debug.Log($"Обновление времени: {_timerText.text}");
    }

    private void OnTimerStart()
    {
        _stateText.text = "Таймер запущен";
        Debug.Log("Таймер запущен");
    }

    private void OnTimerFinish()
    {
        _timerText.text = _finishMessage;
        _stateText.text = "Таймер завершен";
        Debug.Log("Таймер завершен");
    }

    private void OnFirstPause()
    {
        _stateText.text = "Первая пауза - нажмите Продолжить";
        Debug.Log("Первая пауза");
        _timer.setFirstSattion();
    }

    private void OnSecondPause()
    {
        _stateText.text = "Вторая пауза - нажмите Продолжить";
        Debug.Log("Вторая пауза");
        _timer.setSecondSattion();
    }

    private void OnThirdPause()
    {
        _stateText.text = "Третья пауза - нажмите Продолжить";
        Debug.Log("Третья пауза");
        _timer.setthirdSattion();
    }

    private void OnContinue()
    {
        _stateText.text = "Таймер продолжен";
        Debug.Log("Таймер продолжен");
    }



    public void ContinueGame()
    {
        Debug.Log("Нажата кнопка продолжения");
        if (_timer != null)
        {
            _timer.ContinueTimer();
            Debug.Log("Метод ContinueTimer() вызван");
        }
        else
        {
            Debug.LogError("Таймер не найден!");
        }
    }
}