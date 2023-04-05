using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField, Min(2)] private int _numBullet;
    [SerializeField, Min(0)] private float _corner;

    public override void Attack()
    {
        float startCorrner = - _corner / 2f;
        float deltaCornet = _corner / (_numBullet-1);

        for(int i = 0; i < _numBullet; i++)
        {
            Transform bullet = _pool.SpawnBullet();
            bullet.position = _spawnBulletPositioin.position;
            bullet.eulerAngles = _spawnBulletPositioin.eulerAngles + new Vector3(0, startCorrner + deltaCornet * i, 0);
        }
    }

    public override void SpecialAttack()
    {
        throw new System.NotImplementedException();
    }
}
