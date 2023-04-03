using UnityEngine;

public class Gun : RangedWeapon
{
    public override void Attack()
    {
        Transform bullet = _pool.SpawnBullet();
        bullet.position = _spawnBulletPositioin.position;
        bullet.rotation = _spawnBulletPositioin.rotation;
    }

    public override void SpecialAttack()
    {

    }
}
