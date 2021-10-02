using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public float healthPoint;

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        this.healthPoint -= damage;
        if (this.healthPoint <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
