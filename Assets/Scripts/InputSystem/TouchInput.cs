using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private TouchInputUI _ui;
    [SerializeField] private float _joystickRadius;

    private Canvas _canvas;
    private Vector2 _startPos;

    public event System.Action<Vector2> Drag;
    public event System.Action PointerDown;
    public event System.Action PointerUp;

    private void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - _startPos;

        float radius = Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y) / _canvas.scaleFactor;

        if(radius >= _joystickRadius)
        {
            delta = delta.normalized * _joystickRadius;
        }

        _ui.Drag(delta);

        Drag?.Invoke(delta / _joystickRadius);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPos = eventData.position;

        _ui.PointerDown(eventData.position);
        PointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _ui.PointerUp(eventData.position);
        PointerUp?.Invoke();
    }
}
