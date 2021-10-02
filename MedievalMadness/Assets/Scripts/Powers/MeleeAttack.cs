using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage = 3;

    private void Start()
    {
        Destroy(this.gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<MonsterBase>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Civil"))
        {
            collision.gameObject.GetComponent<Civil>().Death();
        }

    }
}
