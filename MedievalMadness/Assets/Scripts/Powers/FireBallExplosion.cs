using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallExplosion : MonoBehaviour
{
    public float damage = 3;
    private bool dealDamage = true;

    private void Start()
    {
        Invoke("undealDamage", 0.2f);              
        Destroy(this.gameObject, 2.0f);     // keep object alive for animation

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dealDamage){

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


    private void undealDamage(){
        dealDamage = false;
    }

}
