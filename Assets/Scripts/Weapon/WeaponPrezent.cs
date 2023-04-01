using UnityEngine;
using Sirenix.OdinInspector;

public class WeaponPrezent : MonoBehaviour
{
    [ShowInInspector] private IWeapon _weapon;

    public IWeapon Weapon => _weapon;
}
