using System.Collections;
using UnityEngine;

public class EnemyShooterController : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _delay = 1f;

    private Coroutine _shootDelayed;

    private void OnEnable()
    {
        _shootDelayed = StartCoroutine(ShootDelayed());
    }

    private void OnDisable()
    {
        if (_shootDelayed != null)
        {
            StopCoroutine(_shootDelayed);
            _shootDelayed = null;
        }
    }

    private IEnumerator ShootDelayed()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (true)
        {
            yield return delay;
            _shooter.TryShoot();
        }
    }
}