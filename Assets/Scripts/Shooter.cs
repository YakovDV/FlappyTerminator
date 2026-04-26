using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _cooldown = 0.2f;
    [SerializeField] private BulletOwner _owner;

    private bool _canShoot;
    private Coroutine _shootWithCooldown;

    private void OnEnable()
    {
        _canShoot = true;
    }

    public void TryShoot()
    {
        if (_canShoot == false)
        {
            return;
        }
        else
        {
            if (_shootWithCooldown != null)
            {
                StopCoroutine(_shootWithCooldown);
                _shootWithCooldown = null;
            }

            _shootWithCooldown = StartCoroutine(ShootWithCooldown());
        }
    }

    private IEnumerator ShootWithCooldown()
    {
        _canShoot = false;
        Bullet bullet = _bulletPool.GetObject();

        bullet.transform.position = transform.position;

        bullet.ReadyToReturn += ReturnBullet;
        bullet.Move(transform.right);
        bullet.SetOwner(_owner);

        yield return new WaitForSeconds(_cooldown);

        _canShoot = true;
    }

    private void ReturnBullet(Bullet bullet)
    {
        bullet.ReadyToReturn -= ReturnBullet;
        _bulletPool.ReleaseObject(bullet);
    }
}