using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Projectile"))
        {
            GameObject effect = Instantiate(hitEffect, this.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)) /*or Quaternion.identity pour rotation nulle*/);
            Destroy(effect, 0.2f);
            Destroy(this.gameObject);
        }
    }
}
