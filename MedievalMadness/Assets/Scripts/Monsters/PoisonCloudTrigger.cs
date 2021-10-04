using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloudTrigger : MonoBehaviour
{
    public GameObject poisonCloudPrefab;
    public float projectileForce;

    private float timeUntilNextCloud;
    public float cloudRate = 2.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Civil") && timeUntilNextCloud <= 0 )
        {
            Vector2 direction = collision.gameObject.transform.position - this.transform.position;
            Debug.Log(direction);

            GameObject projectile = Instantiate(poisonCloudPrefab, this.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(direction.normalized * projectileForce, ForceMode2D.Impulse);

            timeUntilNextCloud = cloudRate;
        }
        

    }

    private void Update()
    {
        if (timeUntilNextCloud > 0)
        {
            timeUntilNextCloud -= Time.deltaTime;

        }
    }
}
