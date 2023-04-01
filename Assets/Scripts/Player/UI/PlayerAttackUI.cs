using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackUI : MonoBehaviour
{
    [SerializeField] private Button _weaponRaiseButton;

    private void Start()
    {
        _weaponRaiseButton.gameObject.SetActive(false);
    }

    public void WeaponRaiseButtonEnable()
    {
        _weaponRaiseButton.gameObject.SetActive(true);
    }
    public void WeaponRaiseButtonDisable()
    {
        _weaponRaiseButton.gameObject.SetActive(false);
    }
}
