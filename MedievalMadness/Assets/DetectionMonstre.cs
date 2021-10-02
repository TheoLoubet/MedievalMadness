using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMonstre : MonoBehaviour
{
    public GameObject parent;

    void OnTriggerEnter2D(Collider2D other) 
    {
        print("f");
        if(other.gameObject.CompareTag("Monster"))
        {
            print("ff");
            parent.GetComponent<AIController>().Fleeing(other.transform.position);
        }
    }
}
