using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackNavigation : MonoBehaviour
{
    [SerializeField, Min(0)] private float _angle;
    [SerializeField] private PlayerAttackNavigationPrezent _prezent;

    [SerializeField] private List<EnemTest> _enemList = new List<EnemTest>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemTest enemy))
        {
            _enemList.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemTest enemy))
        {
            _enemList.Remove(enemy);
        }
    }

    public void StopNavigation()
    {
        _prezent.StopPrezent();
    }

    public Vector3 GetEnemyPos(Vector3 direction)
    {
        Quaternion rot = Quaternion.LookRotation(direction);

        Vector3 newDir = direction;
        Vector3 pos = Vector3.zero;

        float delta = float.MaxValue;
      
        foreach(var enemy in _enemList)
        {
            Vector3 l = enemy.transform.position - Vector3.Scale(transform.position, new Vector3(1, 0, 1));
            Vector3 normal = l.normalized;

            Quaternion rot2 = Quaternion.LookRotation(normal);


            if(delta > Quaternion.Angle(rot2, rot))
            {
                newDir = l;
                pos = enemy.transform.position;
                delta = Quaternion.Angle(rot2, rot);
            }

        }

        if (delta < _angle / 2f)
        {
            _prezent.StartPrezent();
            _prezent.UpdatePos(pos);
            return newDir.normalized;
        }

        _prezent.StopPrezent();

        return direction.normalized;
    }

}
