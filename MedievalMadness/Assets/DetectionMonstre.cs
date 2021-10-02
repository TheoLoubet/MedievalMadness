using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMonstre : MonoBehaviour
{
    public GameObject parent;

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            parent.GetComponent<AIController>().Fleeing(other.transform.position);
        }
    }
}
