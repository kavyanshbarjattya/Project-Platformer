using UnityEngine;
using System.Collections;

public class BulletShoot_Enemy : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _shootTrans;
    [SerializeField] float _fireRate;

    float _nextTimeToShoot = 0;

    private void Update()
    {
        if (Time.time >= _nextTimeToShoot)
        {
            BulletShoot(_bulletPrefab);
            _nextTimeToShoot = (int)(Time.time + 1/_fireRate);
        }
    }

    void BulletShoot(GameObject bullet)
    {
        Instantiate(bullet,_shootTrans.position, Quaternion.identity) ;
    }


}
