using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EntityState
{
    protected Entity _entity;

    public EntityState(Entity entity)
    {
        _entity = entity;
    }

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void Stop() { }

    public virtual void StartMove() { }
    public virtual void StopMove() { }
    public virtual void UpdateRot(Vector3 direction) { }
}
