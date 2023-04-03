using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;
    [SerializeField, Min(0)] private int _damage;
    [SerializeField, Min(0)] private float _timeLive;

    private Coroutine _liveCoroutine;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        _liveCoroutine = StartCoroutine(LiveTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Disable();
    }

    private IEnumerator LiveTimer()
    {
        yield return new WaitForSecondsRealtime(_timeLive);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Disable();
    }

    private void Disable()
    {
        if (_liveCoroutine != null)
        {
            StopCoroutine(_liveCoroutine);
            gameObject.SetActive(false);
        }
    }
}
