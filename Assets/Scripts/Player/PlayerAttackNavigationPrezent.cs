using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackNavigationPrezent : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    [SerializeField] private GameObject _obj;

    private void Awake()
    {
        _obj = Instantiate(_prefab);
        _obj.SetActive(false);
    }

    public void StartPrezent()
    {
        _obj.SetActive(true);
    }

    public void UpdatePos(Vector3 pos)
    {
        _obj.transform.position = pos;
    }

    public void StopPrezent()
    {
        _obj.SetActive(false);
    }
}
