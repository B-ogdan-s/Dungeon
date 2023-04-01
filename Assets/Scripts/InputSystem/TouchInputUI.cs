using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInputUI : MonoBehaviour
{
    [SerializeField] private RectTransform _joystick;

    private RectTransform _transform;

    private Vector2 _startPos;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        _startPos = _transform.position;
    }

    public void Drag(Vector2 pos)
    {
        _joystick.position = pos + (Vector2)_transform.position;
    }

    public void PointerDown(Vector2 pos)
    {
        _transform.position = pos;
    }

    public void PointerUp(Vector2 pos)
    {
        _transform.position = _startPos;
        _joystick.localPosition = Vector2.zero;
    }
}
