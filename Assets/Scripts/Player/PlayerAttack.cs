using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerAttackUI _attackUI;
    [ShowInInspector] private IWeapon _weapon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WeaponPrezent weaponPrezent))
        {
            _attackUI.WeaponRaiseButtonEnable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out WeaponPrezent weaponPrezent))
        {
            _attackUI.WeaponRaiseButtonDisable();
        }
    }
}
