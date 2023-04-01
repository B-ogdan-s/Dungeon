using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdelState : EntityState
{
    private PlayerMove _playerMove;
    public PlayerIdelState(Entity entity, PlayerMove playerMove) : base(entity)
    {
        _playerMove = playerMove;
    }
    public override void StartMove()
    {
        _entity.ChangeState<PlayerMoveState>();
    }
    public override void UpdateRot(Vector3 direction)
    {
        _playerMove.Rotete(direction);
    }
}
