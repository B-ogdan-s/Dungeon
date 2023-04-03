using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField, Min(0)] private int _numBullet;
    [SerializeField, Min(0)] private float _corner;

    public override void Attack()
    {
        for(int i = 0; i < _numBullet; i++)
        {
            Transform bullet = _pool.SpawnBullet();
            bullet.position = _spawnBulletPositioin.position;
            bullet.eulerAngles = _spawnBulletPositioin.eulerAngles + new Vector3(0, Random.Range(-_corner, _corner), 0);
        }
    }

    public override void SpecialAttack()
    {
        throw new System.NotImplementedException();
    }
}
