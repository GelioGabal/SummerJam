using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Timer : MonoBehaviour
{
    [SerializeField] private float minTime = 10f;
    [SerializeField] private float maxTime = 30f;
    [Tooltip("Выбранное рандомное число умножится на данную переменную")] [SerializeField] [Range(0.5f, 5f)] private float timeScale = 1f;
    private float _currentTimer;
    private bool _isActive;

    [Header("Events")] 
    public UnityEvent<GameObject> OnTimerExpired;

    private void Awake()
    {
        OnTimerExpired.AddListener((gameObject) => 
        {
            Debug.Log($"Таймер у объекта {gameObject.name} истек");
        });
    }

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (!_isActive) return;

        _currentTimer -= Time.deltaTime;// * timeScale;

        if (_currentTimer <= 0)
        {
            EndTimer();
        }
    }

    private void EndTimer()
    {
        _isActive = false;
        OnTimerExpired?.Invoke(gameObject);
    }

    public void ResetTimer()
    {
        _currentTimer = Random.Range(minTime, maxTime) * timeScale;
        _isActive = true;
        Debug.Log("Таймер на объекте"+ gameObject.name +" запущен, всего времени: "+ _currentTimer);
    }
}
