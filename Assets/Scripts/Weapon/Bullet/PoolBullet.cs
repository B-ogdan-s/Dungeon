using System.Collections.Generic;
using UnityEngine;

public class PoolBullet
{
    private Bullet _bullet;

    private List<Bullet> _bullets = new List<Bullet>();

    public PoolBullet(Bullet bullet)
    {
        _bullet = bullet;
    }

    public Transform SpawnBullet()
    {
        foreach (Bullet bullet in _bullets)
        {
            if(!bullet.gameObject.active)
            {
                bullet.gameObject.SetActive(true);
                return bullet.transform;
            }
        }

        Bullet bul = MonoBehaviour.Instantiate(_bullet);
        _bullets.Add(bul);
        return bul.transform;
    }
}
