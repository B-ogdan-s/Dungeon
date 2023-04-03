using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackUI : MonoBehaviour
{
    [SerializeField] private Button _weaponRaiseButton;

    public event System.Action OnDownButton;
    private void Start()
    {
        _weaponRaiseButton.gameObject.SetActive(false);
        _weaponRaiseButton.onClick.AddListener(() => OnDownButton?.Invoke());
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
