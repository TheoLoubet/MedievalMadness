using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float damage = 7;

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
        GameObject effect = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
        //Destroy(effect, 0.1f);
        Destroy(this.gameObject);
    }
}
