using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class WeaponPrezent : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private GameObject _obj;

    public Weapon Weapon
    {
        get
        {
            Destroy(_obj);
            _obj = null;
            gameObject.SetActive(false);
            return _weapon;
        }
    }

    private void OnEnable()
    {
        _obj = Instantiate(_weapon, transform).gameObject;
        _obj.transform.localPosition = Vector3.zero;
    }
}
