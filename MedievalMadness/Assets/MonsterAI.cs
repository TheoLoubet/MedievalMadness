using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Vector3 currentPos;
    //Start is called at Start
    private void Start() 
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
		agent.updateUpAxis = false;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject oMin = null;
        float minDist = 100;
        currentPos = transform.position;
        goalLocations = GameObject.FindGameObjectsWithTag("Civil");
        foreach (GameObject o in goalLocations)
        { 
            float dist = Vector3.Distance(o.transform.position,currentPos);
            if(dist < minDist)
            {
                oMin = o;
                minDist = dist;
            }
        }
        agent.SetDestination(oMin.transform.position);
    }
}
