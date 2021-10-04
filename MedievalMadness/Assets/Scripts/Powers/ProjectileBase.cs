using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<MonsterBase>().TakeDamage(this.damage);
        }
        else if (collision.gameObject.CompareTag("Civil"))
        {
            collision.gameObject.GetComponent<Civil>().Death();
        }
        GameObject effect = Instantiate(hitEffect, this.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)) /*or Quaternion.identity pour rotation nulle*/);
        Destroy(effect, 0.2f);
        Destroy(this.gameObject);
    }
}
