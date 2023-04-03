using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TouchInput _move;
    [SerializeField] private TouchInput _look;

    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAttack _playerAttack;

    private Entity _entity;

    private void Start()
    {
        _entity = new Entity();

        _move.Drag += UpdateDirection;
        _move.Drag += UpdateRotate;
        _move.PointerDown += StartMove;
        _move.PointerUp += StopMove;

        _look.PointerDown += StartAttack;
        _look.PointerUp += StopAttack;


        List<EntityState> stateList = new List<EntityState>()
        {
            new PlayerIdelState(_entity, _playerMove),
            new PlayerMoveState(_entity, _playerMove)

        };
        _entity.StatesList = stateList;
        _entity.ChangeState<PlayerIdelState>();
    }

    private void Update()
    {
        _entity.State.Update();
    }
    #region Move
    private void StartMove()
    {
        _entity.State.StartMove();
    }
    private void StopMove()
    {
        _entity.State.StopMove();
        _playerMove.UpdateDirection(Vector3.zero);
    }
    private void UpdateDirection(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);
        _playerMove.UpdateDirection(newDirection);
    }

    private void UpdateRotate(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);
        _entity.State.UpdateRot(newDirection);
    }
    #endregion

    #region Attack

    private void StartAttack()
    {
        _move.Drag -= UpdateRotate;
        _look.Drag += UpdateRotate;

        _playerAttack.StartAttack();
    }
    private void StopAttack()
    {
        _look.Drag -= UpdateRotate;
        _move.Drag += UpdateRotate;
        _entity.State.UpdateRot(_playerMove.MoveDirection);

        _playerAttack.StopAttack();
    }

    #endregion

    private void OnDestroy()
    {
        _move.Drag -= UpdateDirection;
        _look.Drag -= UpdateRotate;
        _move.PointerDown -= StartMove;
        _move.PointerUp -= StopMove;

        _look.PointerDown -= StartAttack;
        _look.PointerUp -= StopAttack;
    }
}
