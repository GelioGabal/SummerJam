using System;
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
    private bool _isDraged = false;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();
    }

    private void Start()
    {
        // ResetLineRenderer();
    }

    private void Update()
    {
        if (_wireTask.isAllSolved) return;
        
        if (_isDraged)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);
        
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else  if (isSolved)
        {
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1,Vector3.zero);
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);
        if (isHovered)
        {
            _wireTask.curHoveredWire =  this;
        }
    }

    public void SetColor(Color color)
    {
        _image.color = color;
        // _lineRenderer.SetColors(color, color);
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        customColor =  color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isLeftWire || !isSolved) return;
        
        _isDraged = true;
        _wireTask.curWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wireTask.curHoveredWire != null)
        {
            if (_wireTask.curHoveredWire.customColor == customColor && !_wireTask.curHoveredWire.isLeftWire)
            {
                isSolved = this;
                _wireTask.curHoveredWire.isSolved = true;
            }
        }
        
        _isDraged = false;
        _wireTask.curWire = null;

        if (!_wireTask.isAllSolved) _wireTask.CheckSolvedWires();
    }
    
    private void ResetLineRenderer()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
    
        // Базовые настройки
        lr.positionCount = 2;
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.right * 2); // Линия длиной 2 единицы
    
        // Критически важные параметры
        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;
    
        // Материал и цвет
        lr.material = new Material(Shader.Find("Unlit/Color"));
        lr.material.color = Color.red;
    
        // Порядок отрисовки
        lr.sortingLayerName = "UI";
        lr.sortingOrder = 10;
    
        // Гарантированно включить
        lr.enabled = true;
    }
}
