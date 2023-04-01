using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : EntityState
{
    private PlayerMove _playerMove;
    public PlayerMoveState(Entity entity, PlayerMove playerMove) : base(entity)
    {
        _playerMove = playerMove;
    }

    public override void Update()
    {
        _playerMove.Move();
    }
    public override void StopMove()
    {
        _entity.ChangeState<PlayerIdelState>();
    }
    public override void UpdateRot(Vector3 direction)
    {
        _playerMove.Rotete(direction);
    }
}
