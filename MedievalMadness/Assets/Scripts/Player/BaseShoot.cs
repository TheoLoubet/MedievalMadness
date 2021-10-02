using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Axis trigger > 0 -> right trigger | < 0 -> left trigger

public class BaseShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float bulletForce = 20f;
    public float fireRate = 0.2f;
    float timeUntilNextShoot = 0f;

    void Update()
    {
        timeUntilNextShoot -= Time.deltaTime;

        if (Mathf.Round(Input.GetAxisRaw("Trigger")) > 0 && timeUntilNextShoot <= 0)
        {
            Shoot();

            timeUntilNextShoot = fireRate;
        }

    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
