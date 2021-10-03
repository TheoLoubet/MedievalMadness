using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint;

    //sound
    public AudioSource[] audiosources;
    public AudioClip[] audioclips;
    public bool playMadnessSound = true;


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
    public float meleeRate = 2f;
    private float timeUntilNextMelee = 0f;

    // FireBall
    public GameObject fireBallPrefab;
    public float fireBallForce = 20f;
    public float fireBallRate = 3f;
    private float timeUntilNextFireBall = 0f;

    // Laser
    public Transform laser;
    public float laserDuration = 5f;
    public float laserRate = 10f;
    private float timeUntilNextLaser = 0f;


    // Animation
    public Animator animator;   // handle all player animations

    // Madness mode
    private bool isMadness = true;

    

    void Update()
    {
        bool isMadness = GetComponent<Player>().isMadness;


        
        //to play sound madness only once
        if(isMadness == true)
        {
            if(playMadnessSound == true)
            {
                audiosources[6].PlayOneShot(audioclips[6],1f);
                playMadnessSound = false;
            }
        }
        if(isMadness == false)
        {
            playMadnessSound = true;
        }


        // Shoot
        if (timeUntilNextShoot > 0)
        {
            timeUntilNextShoot -= Time.deltaTime;
        }
        if (Input.GetAxisRaw("RightTrigger") > 0 && timeUntilNextShoot <= 0 && laser.gameObject.activeSelf == false)
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
        if (Input.GetButtonDown("SlowZone") && timeUntilNextSlowZone <= 0 && laser.gameObject.activeSelf == false)
        {
            SlowZone();
        }

        // Melee Attack
        if (timeUntilNextMelee > 0)
        {
            timeUntilNextMelee -= Time.deltaTime;
        }
        if (Input.GetButtonDown("MeleeAttack") && timeUntilNextMelee <= 0 && laser.gameObject.activeSelf == false)
        {
            animator.SetBool("IsFighting", true);   // play fight animation

            if (!isMadness)
            {
                timeUntilNextMelee = meleeRate;
            }
            else
            {
                timeUntilNextMelee = meleeRate / 2;
            }

            Invoke("Melee",0.5f);
            Invoke("stopMeleeAnimation", 0.1f);

        }

        // Fire Ball
        if (timeUntilNextFireBall > 0)
        {
            timeUntilNextFireBall -= Time.deltaTime;
        }
        if (Input.GetButtonDown("FireBall") && timeUntilNextFireBall <= 0 && laser.gameObject.activeSelf == false)
        {
            if (!isMadness)
            {
                FireBall();
            }
            else
            {
                FireBall();
                Invoke("FireBall", 0.25f);
                Invoke("FireBall", 0.5f);
            }
        }

        // Laser
        if (timeUntilNextLaser > 0)
        {
            timeUntilNextLaser -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Laser") && timeUntilNextLaser <= 0)
        {
            //soundlaser
            audiosources[4].PlayOneShot(audioclips[4],1f);
            audiosources[5].Play();
            laser.gameObject.SetActive(true);
            Invoke("StopLaser", laserDuration);

            if (isMadness)
            {
                SlowZone();
                FireBallRandom();
                FireBallRandom();
                FireBallRandom();
                FireBallRandom();
                FireBallRandom();
            }

        }

    }

    void Shoot()
    {
        //sound
        audiosources[0].PlayOneShot(audioclips[0],1f);

        if(!isMadness)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);

            GameObject projectile2 = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 15));
            Rigidbody2D projectile2Rb = projectile2.GetComponent<Rigidbody2D>();
            projectile2Rb.AddForce(projectile2.transform.up * projectileForce, ForceMode2D.Impulse);

            GameObject projectile3 = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -15));
            Rigidbody2D projectile3Rb = projectile3.GetComponent<Rigidbody2D>();
            projectile3Rb.AddForce(projectile3.transform.up * projectileForce, ForceMode2D.Impulse);
        }

        

        timeUntilNextShoot = fireRate;
    }

    void SlowZone()
    {
        //sound
        audiosources[2].PlayOneShot(audioclips[2],1f);

        GameObject slowZone = Instantiate(slowZonePrefab, this.transform.position, Quaternion.identity);
        if(isMadness)
        {
            slowZone.transform.localScale += new Vector3(6f, 6f, 0f);
        }

        timeUntilNextSlowZone = slowZoneRate;
    }

    void Melee()
    {
        //sound
        audiosources[3].PlayOneShot(audioclips[3],1f);
        GameObject meleeAttack = Instantiate(meleeAttackPrefeb, firePoint.position, firePoint.rotation);
        meleeAttack.transform.parent = this.transform;
       
    }

    void stopMeleeAnimation(){
        animator.SetBool("IsFighting", false);   // stop playing fight animation
    }

    void FireBall()
    {
        //sound
        audiosources[1].PlayOneShot(audioclips[1],1f);
        GameObject fireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D fireBallRB = fireBall.GetComponent<Rigidbody2D>();
        fireBallRB.AddForce(firePoint.up * fireBallForce, ForceMode2D.Impulse);

        timeUntilNextFireBall = fireBallRate;
    }

    void StopLaser()
    {
        audiosources[5].Stop();
        laser.gameObject.SetActive(false);
        timeUntilNextLaser = laserRate;
    }

    void FireBallRandom()
    {
        //sound
        audiosources[1].PlayOneShot(audioclips[1], 1f);
        GameObject fireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-90f, 90f)));
        Rigidbody2D fireBallRB = fireBall.GetComponent<Rigidbody2D>();
        fireBallRB.AddForce(fireBall.transform.up * fireBallForce, ForceMode2D.Impulse);

        timeUntilNextFireBall = fireBallRate;
    }
}
