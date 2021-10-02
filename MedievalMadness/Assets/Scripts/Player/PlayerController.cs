using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint;

    // Shoot
    public GameObject projectilePrefab;
    public float projectileForce = 30f;
    public float fireRate = 0.2f;
    private float timeUntilNextShoot = 0f;

    // SlowZone
    public GameObject slowZonePrefab;
    public float slowZoneRate = 5f;
    private float timeUntilNextSlowZone = 0f;

    // MeleeAttack
    public GameObject meleeAttackPrefeb;
    public float meleeRate = 5f;
    private float timeUntilNextMelee = 0f;

    // FireBall
    public GameObject fireBallPrefab;
    public float fireBallForce = 10f;
    public float fireBallRate = 5f;
    private float timeUntilNextFireBall = 0f;


    // Animation
    public Animator animator;   // handle all player animations 



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
            animator.SetBool("IsFiring", true);     // play firing animation
        }else
        {
            animator.SetBool("IsFiring", false);     // stop playing animation
        }

        // Slow Zone
        if (timeUntilNextSlowZone > 0)
        {
            timeUntilNextSlowZone -= Time.deltaTime;
        }
        if (Input.GetButtonDown("SlowZone") && timeUntilNextSlowZone <= 0)
        {
            SlowZone();
        }

        // Melee Attack
        if (timeUntilNextMelee > 0)
        {
            timeUntilNextMelee -= Time.deltaTime;
        }
        if (Input.GetButtonDown("MeleeAttack") && timeUntilNextMelee <= 0)
        {
            animator.SetBool("IsFighting", true);   // play fight animation
            Invoke("Melee",0.5f);
            Invoke("stopMeleeAnimation", 0.1f);

        }

        // Fire Ball
        if (timeUntilNextFireBall > 0)
        {
            timeUntilNextFireBall -= Time.deltaTime;
        }
        if (Input.GetButtonDown("FireBall") && timeUntilNextFireBall <= 0)
        {
            FireBall();
        }

    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);

        timeUntilNextShoot = fireRate;
    }

    void SlowZone()
    {
        GameObject slowZone = Instantiate(slowZonePrefab, this.transform.position, Quaternion.identity);

        timeUntilNextSlowZone = slowZoneRate;
    }

    void Melee()
    {
        GameObject meleeAttack = Instantiate(meleeAttackPrefeb, firePoint.position, firePoint.rotation);
        meleeAttack.transform.parent = this.transform;

        timeUntilNextMelee = meleeRate;
    }

    void stopMeleeAnimation(){
        animator.SetBool("IsFighting", false);   // stop playing fight animation
    }

    void FireBall()
    {
        GameObject fireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D fireBallRB = fireBall.GetComponent<Rigidbody2D>();
        fireBallRB.AddForce(firePoint.up * fireBallForce, ForceMode2D.Impulse);

        timeUntilNextFireBall = fireBallRate;
    }
}
