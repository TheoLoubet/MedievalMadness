using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Shoot
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.2f;
    private float timeUntilNextShoot = 0f;

    // SlowZone
    public GameObject slowZonePrefab;
    public float slowZonePower;


    void Update()
    {
        // Shoot
        if (timeUntilNextShoot > 0)
        {
            timeUntilNextShoot -= Time.deltaTime;
        }
        if (Input.GetAxisRaw("RightTrigger") > 0 && timeUntilNextShoot <= 0)
        {
            Shoot();

            timeUntilNextShoot = fireRate;
        }
        if(Input.GetButtonDown("SlowZone"))
        {
            SlowZone();
        }


    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void SlowZone()
    {
        GameObject slowZone = Instantiate(slowZonePrefab, this.transform.position, Quaternion.identity);
        

    }
}
