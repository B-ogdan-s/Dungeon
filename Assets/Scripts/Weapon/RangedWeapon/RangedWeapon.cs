using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _recharge;

    public abstract void Attack();
    public abstract void SpecialAttack();
}
