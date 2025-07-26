using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    [HideInInspector] public bool IsSolved = true;
    [SerializeField] private int[] availableAngles = { 45, 90, 135, 180, 225, 270, 315 };
    [SerializeField] private float angleGap = 45f;
    [SerializeField] private float targetAngle = 0f;
    private RotatorsPanel panel; 
    private float _currentAngle; 
    
    public UnityEvent OnSolve;

    private void Awake()
    {
        if (panel == null)
        {
            panel = GetComponentInParent<RotatorsPanel>();
        }

        if (panel != null)
        {
            panel.AddRotator(this);
            OnSolve.AddListener(panel.CheckAllSolved);
        }

        OnSolve.AddListener(() =>
        {
            Debug.Log("Кружок прокручен верно");
        });

        IsSolved = true;
    }
    
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider && hit.collider.gameObject == gameObject)
        {
            Rotate();
        }
    }

    public void Rotate()
    {
        if (IsSolved) return;
        
        RotateToAngle(_currentAngle+angleGap);
        CheckAngle();
    }
    
    public void RotateToRandomAngle()
    {
        var randomIndex = Random.Range(0, availableAngles.Length);
        RotateToAngle(availableAngles[randomIndex]);
        IsSolved = false;
    }
    
    private void RotateToAngle(float angle)
    {
        var normalizedAngle = NormalizeAngle(angle);
        transform.localEulerAngles = new Vector3(0, 0, normalizedAngle);
        _currentAngle = NormalizeAngle(transform.localEulerAngles.z);
    }

    private void CheckAngle()
    {
        if (!Mathf.Approximately(NormalizeAngle(_currentAngle), NormalizeAngle(targetAngle)))
        {
            IsSolved = false;
            return;
        }
        IsSolved = true;
        OnSolve?.Invoke();
    }
    
    private float NormalizeAngle(float angle)
    {
        angle %= 360;
        if (angle < 0)
            angle += 360;
        return angle;
    }
}