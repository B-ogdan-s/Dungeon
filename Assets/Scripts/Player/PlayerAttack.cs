using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;

    private Coroutine _attackCoroutine;

    private bool _isAttacking = true;

    public void StartAttack()
    {
        if (_playerWeapon.Weapon == null)
            return;

        _isAttacking = true;

        if(_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(Attack());
        }
    }

    public void StopAttack()
    {
        _isAttacking = false;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        do
        {
            _playerWeapon.Weapon.Attack();
            yield return new WaitForSecondsRealtime(_playerWeapon.Weapon.AttackPause);

        } while (_isAttacking);

        _attackCoroutine = null;
    }
}
