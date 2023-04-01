using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateChange
{
    public void ChangeState<T>() where T: EntityState;
}
