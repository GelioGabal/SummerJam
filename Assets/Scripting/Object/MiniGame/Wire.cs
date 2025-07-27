using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool isLeftWire;
    public bool isSolved = false;
    public Color customColor;
   
    private WireTask _wireTask;
    private Canvas _canvas;
    private Image _image;
    private LineRenderer _lineRenderer;
    private bool _isDragged = false;
    
    private Vector3 _solvedEndPosition;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();
    }

    private void Update()
    {
        if (_wireTask.isAllSolved) return;
        
        if (_isDragged)
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 10f; 
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
            
            SetLinePosition(Camera.main.ScreenToWorldPoint(transform.position), mouseWorldPos);
        }
        else if (!isSolved)
        {
            SetLinePosition(Vector3.zero,  Vector3.zero);
        }
        
        if (RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera))
        {
            _wireTask.hovWire =  this;
        }
    }

    private void SetLinePosition(Vector3 startPosition, Vector3 endPosition)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);
    }

    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        _lineRenderer.material.color = color;
        
        customColor =  color;
    }

    public void OnDrag(PointerEventData eventData) {}

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isLeftWire || isSolved) return;
        
        _lineRenderer.enabled = true;
        
        _isDragged = true;
        _wireTask.curWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wireTask.hovWire != null)
        {
            if (_wireTask.hovWire.customColor == customColor && 
                !_wireTask.hovWire.isLeftWire)
            {
                isSolved = true;
                _wireTask.hovWire.isSolved = true;
            }
            else if (!isSolved)
            {
                _lineRenderer.enabled = false;
            }
        }
        
        _isDragged = false;
        _wireTask.curWire = null;
        _wireTask.hovWire = null;

        if (!_wireTask.isAllSolved) 
            _wireTask.CheckSolvedWires();
    }
}
