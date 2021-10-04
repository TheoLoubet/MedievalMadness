using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonster : MonsterBase
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Civil"))
        {
            //collision.gameObject.GetComponent<Civil>().Death();
            Debug.Log("SpawnCloud");
        }
    }



}
