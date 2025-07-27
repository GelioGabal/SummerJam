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
    private RectTransform  _rectTransform;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();
        _rectTransform = _canvas.GetComponent<RectTransform>();

    }
    private void Update()
    {
        if (_wireTask.isAllSolved) return;
        
        if (_isDragged)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos
            );
            Vector3 mouseWorldPos = _canvas.transform.TransformPoint(movePos);
            
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, mouseWorldPos);

            Debug.Log($"Dragged: end position: {mouseWorldPos} ");
        }
        else if (!isSolved)
        {
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
        }
        // else  if (isSolved)
        // {
        //     _lineRenderer.SetPosition(0, transform.position);
        //     _lineRenderer.SetPosition(1, _solvedEndPosition);
        //     Debug.Log($"isSolved: end position: {_solvedEndPosition} ");
        // }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);
        if (isHovered)
        {
            _wireTask.hovWire =  this;
        }
    }

    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        _lineRenderer.material.color = color;
        
        customColor =  color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isLeftWire)
        {
            Debug.Log("Is right wire, don't move");
            return;
        }

        if (isSolved)
        {
            Debug.Log("Is left wire, but solved, don't draw more lines");
            return;
        }
        
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
                
                // _solvedEndPosition = _wireTask.hovWire.transform.position;
                // Debug.Log(_solvedEndPosition + " _solvedEndPosition");
            }
            else if (!isSolved)
            {
                _lineRenderer.enabled = false;
            }
        }
        
        _isDragged = false;
        _wireTask.curWire = null;
        _wireTask.hovWire = null;

        // if (!_wireTask.isAllSolved) 
            _wireTask.CheckSolvedWires();
    }
}
