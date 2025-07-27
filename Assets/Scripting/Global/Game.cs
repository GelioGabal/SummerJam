using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("UI ��������")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _stateText;

    [Header("���������")]
    [SerializeField] private string _timeFormat = "mm':'ss";
    [SerializeField] private string _finishMessage = "����� �����!";

    private FlexibleTimer _timer;

    private void Awake()
    {
        Debug.Log("Game.Awake()");
        _timer = GetComponent<FlexibleTimer>();
        _timer.StartTimer(20);
    }

    public void StartGame(int durationInSeconds)
    {
        Debug.Log($"������ ������� �� {durationInSeconds} ������");
        _timer.StartTimer(durationInSeconds);
    }

    private void OnEnable()
    {
        Debug.Log("�������� �� ������� �������");
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
        Debug.Log($"���������� �������: {_timerText.text}");
    }

    private void OnTimerStart()
    {
        _stateText.text = "������ �������";
        Debug.Log("������ �������");
    }

    private void OnTimerFinish()
    {
        _timerText.text = _finishMessage;
        _stateText.text = "������ ��������";
        Debug.Log("������ ��������");
    }

    private void OnFirstPause()
    {
        _stateText.text = "������ ����� - ������� ����������";
        Debug.Log("������ �����");
        _timer.setFirstSattion();
    }

    private void OnSecondPause()
    {
        _stateText.text = "������ ����� - ������� ����������";
        Debug.Log("������ �����");
        _timer.setSecondSattion();
    }

    private void OnThirdPause()
    {
        _stateText.text = "������ ����� - ������� ����������";
        Debug.Log("������ �����");
        _timer.setthirdSattion();
    }

    private void OnContinue()
    {
        _stateText.text = "������ ���������";
        Debug.Log("������ ���������");
    }



    public void ContinueGame()
    {
        Debug.Log("������ ������ �����������");
        if (_timer != null)
        {
            _timer.ContinueTimer();
            Debug.Log("����� ContinueTimer() ������");
        }
        else
        {
            Debug.LogError("������ �� ������!");
        }
    }
}