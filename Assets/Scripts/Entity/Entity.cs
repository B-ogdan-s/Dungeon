using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : IStateChange
{
    private EntityState _state;

    public List<EntityState> StatesList;

    public EntityState State => _state;

    public void ChangeState<T>() where T : EntityState
    {
        EntityState newState = StatesList.FirstOrDefault(x => x is T);

        if (newState == null)
            return;

        _state?.Stop();
        _state = newState;
        _state?.Start();
    }
}
