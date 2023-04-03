using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _attackPause;
    public float AttackPause => _attackPause;

    public abstract void Attack();
    public abstract void SpecialAttack();
}
