using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _modelTransform;

    CharacterController _characterController;

    private Vector3 _moveDirection;

    public Vector3 MoveDirection => _moveDirection;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void UpdateDirection(Vector3 newDirection)
    {
        _moveDirection = newDirection;
    }

    public void Move()
    {
        _characterController.Move(_moveDirection * Time.deltaTime * _speed);
    }

    public void Rotete(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        _modelTransform.rotation = Quaternion.LookRotation(direction);
    }
}
