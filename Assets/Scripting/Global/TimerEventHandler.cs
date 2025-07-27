using TMPro;
using UnityEngine;

public class TimerEventHandler : MonoBehaviour
{
    [Header("Ссылки")]
    [SerializeField] private GlobalTimer _timer;
   [SerializeField] private TMP_Text _Timer;
    [SerializeField] private TMP_Text _deepValueText;
    [SerializeField] GameObject[] Check;



    private void OnEnable()
    {
        if (_timer != null)
        {

            _timer.OnFirstPause.AddListener(HandleFirstPause);
            _timer.OnSecondPause.AddListener(HandleSecondPause);
            _timer.OnThirdPause.AddListener(HandleThirdPause);
            _timer.OnTimerFinished.AddListener(HandleTimerFinished);
        }
    }

    private void OnDisable()
    {
        if (_timer != null)
        {
            // Отписываемся от событий
            _timer.OnFirstPause.RemoveListener(HandleFirstPause);
            _timer.OnSecondPause.RemoveListener(HandleSecondPause);
            _timer.OnThirdPause.RemoveListener(HandleThirdPause);
            _timer.OnTimerFinished.RemoveListener(HandleTimerFinished);
        }
    }
    private void Start()
    {
        _timer = GetComponent<GlobalTimer>();
        _timer.StartTimer();
    }

    private void Update()
    {

        if (_deepValueText != null && _timer != null)
        {
            _deepValueText.text = _timer.GetDeep().ToString();
            
            
        }

            
       
    }

   

    private void HandleFirstPause()
    {
        Debug.Log("Обработка первой паузы");
        Check[0].SetActive(true);
        Check[1].SetActive(false);
        Check[2].SetActive(false);
    }

    private void HandleSecondPause()
    {
        Debug.Log("Обработка второй паузы");
        Check[0].SetActive(false);
        Check[1].SetActive(true);
        Check[2].SetActive(false);
    }

    private void HandleThirdPause()
    {
        Debug.Log("Обработка третьей паузы");
        Check[0].SetActive(false);
        Check[1].SetActive(false);
        Check[2].SetActive(true);

    }

    private void HandleTimerFinished()
    {
        Debug.Log("Обработка завершения таймера");
        Check[0].SetActive(false);
        Check[1].SetActive(false);
        Check[2].SetActive(false);
        _timer.StartTimer();

    }
}
