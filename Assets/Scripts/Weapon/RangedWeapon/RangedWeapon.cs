using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected Transform _spawnBulletPositioin;
    [SerializeField] protected float _recharge;

    protected PoolBullet _pool;

    protected virtual void Awake()
    {
        _pool = new PoolBullet(_bullet);
    }
}
