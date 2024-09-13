using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject _firePoint;
    WeaponSelection weaponSelection;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed = 1.0f;
    public float numShots = 1;

    void Awake()
    {
        weaponSelection = GetComponent<WeaponSelection>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(weaponSelection.curSlot == 1)
            {
                weaponSelection.weapon1.transform.GetChild(0).GetComponent<GunAttack>().Fire(_bulletPrefab, _firePoint, this.transform, _bulletSpeed, 2);
            } if(weaponSelection.curSlot == 2)
            {

            } if(weaponSelection.curSlot == 3)
            {

            }
        }
    }

    private void Fire(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.up * speed;
    }
}
