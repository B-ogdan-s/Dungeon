using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private PlayerAttackUI _attackUI;
    [SerializeField] private Transform _spawnWeapon;
    [SerializeField] private Weapon _weapon;

    

    public Weapon Weapon => _weapon;

    private WeaponPrezent _weaponPrezent;

    private void Start()
    {
        _attackUI.OnDownButton += RaiseTheWeapon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WeaponPrezent weaponPrezent))
        {
            _attackUI.WeaponRaiseButtonEnable();
            _weaponPrezent = weaponPrezent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out WeaponPrezent weaponPrezent) && weaponPrezent == _weaponPrezent)
        {
            _attackUI.WeaponRaiseButtonDisable();
            _weaponPrezent = null;
        }
    }

    private void RaiseTheWeapon()
    {
        Weapon weapon = Instantiate(_weaponPrezent.Weapon, _spawnWeapon).GetComponent<Weapon>();
        weapon.transform.localPosition = Vector3.zero;
        _weapon = weapon;
    }
    private void OnDestroy()
    {
        _attackUI.OnDownButton -= RaiseTheWeapon;
    }
}
