using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IEndDragHandler, IDragHandler
{
    public bool isSolved {  get; private set; }
   
    private WireTask _wireTask;
    private LineRenderer _lineRenderer;
    private Wire _target;
    private float _magnetRadius;
    public Vector2 EndPoint => _lineRenderer.GetPosition(1);
    public void Initialize(WireTask wireTask, Wire target, Color color, float magnetRadius)
    {
        _wireTask = wireTask;
        _target = target;
        _magnetRadius = magnetRadius;
        _lineRenderer = GetComponent<LineRenderer>();
        setColor(color);
        isSolved = false;
        Restart();
    }

    public void SetLinePosition(Vector3 endPosition)
    {
        _lineRenderer.SetPosition(0, InputManager.ScreenToWorld(transform.position));
        _lineRenderer.SetPosition(1, InputManager.ScreenToWorld(endPosition));
    }
    public void Restart() => SetLinePosition(transform.position);
    void solve(Wire target)
    {
        isSolved = true;
        target.isSolved = true;
        SetLinePosition(target.transform.position);
    }
    void setColor(Color color)
    {
        GetComponent<Image>().color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        _lineRenderer.material.color = color;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isSolved) return;
        checkSolved();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isSolved) return;
        SetLinePosition(Input.mousePosition);
    }
    void checkSolved()
    {
        if (Vector2.Distance((Vector2)InputManager.WorldToScreen(EndPoint), (Vector2)_target.transform.position) < _magnetRadius)
        {
            solve(_target);
            _wireTask.CheckAllSolved();
        }
        else Restart();
    }
}
