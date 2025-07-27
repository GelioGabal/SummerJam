using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; 
    [SerializeField] private string timeFormat = "mm':'ss"; 
    [SerializeField] private string finishMessage = "Время вышло";

    private FlexibleTimer _timer;

    private void Awake()
    {
        _timer = GetComponent<FlexibleTimer>();
    }

    public void StartGame(int timeInSeconds)
    {
        if (_timer == null)
        {
            Debug.LogError("FlexibleTimer не найден!");
            return;
        }

        _timer.StartTimer(timeInSeconds);
    }

    private void OnEnable()
    {
        if (_timer != null)
        {
            _timer.OnTimeUpdated.AddListener(HandleTimeUpdate);
            _timer.OnTimerFinished.AddListener(HandleTimerFinish);
        }
    }

    private void OnDisable()
    {
        if (_timer != null)
        {
            _timer.OnTimeUpdated.RemoveListener(HandleTimeUpdate);
            _timer.OnTimerFinished.RemoveListener(HandleTimerFinish);
        }
    }

    private void HandleTimeUpdate(float timeLeft)
    {
        
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeLeft);
        timerText.text = timeSpan.ToString(timeFormat);

    }

    //СОБЫТИЕ ПР  ОКОНЧАНИИ ТАЙМЕРА 
    private void HandleTimerFinish()
    {
        timerText.text = finishMessage;
        Debug.Log("Таймер завершил работу");
    }
}
