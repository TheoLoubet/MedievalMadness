using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    
    NavMeshAgent agent;
    Vector3 currentPos;
    private Rigidbody2D rb;

    //Start is called at Start
    private void Start() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    // access to rigidBody2D
        if (!rb) { Debug.Log("ERROR, NO RIGID BODY IN MonsterAI"); }

        agent = this.GetComponent<NavMeshAgent>();      // access to navMeshAgent
        if (!rb) { Debug.Log("ERROR, NONavMeshAgent IN MonsterAI"); }

        agent.updateRotation = false;
		agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // 
        /*GameObject oMin = null;
        float minDist = 100;
        currentPos = transform.position;    // get current position
        goalLocations = GameObject.FindGameObjectsWithTag("Civil");     // get all Civils

        if (goalLocations.Length != 0)  // if still civils alive
        {
            foreach (GameObject o in goalLocations)
            {
                float dist = Vector3.Distance(o.transform.position, currentPos);
                if (dist < minDist)
                {
                    oMin = o;
                    minDist = dist;
                }
            }
            agent.SetDestination(oMin.transform.position);
        }*/

        GameObject goal = GetClosestGoal();
        if (goal) { 
            agent.SetDestination(goal.transform.position);
        }
        else
        {
            Debug.Log("NO GOAL FOUND IN MONSTER AI");
        }

        // Rotate monster
        Vector3 direction = agent.velocity.normalized;
        float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        float currentAngle = rb.rotation;
        currentAngle = Mathf.LerpAngle(currentAngle,endAngle,0.3f);
        rb.rotation = currentAngle;
    }


    GameObject GetClosestGoal()
    {
        GameObject oMin = null;
        float minDist = float.MaxValue;
        currentPos = transform.position;    // get current position
        GameObject[] goalLocations = GameObject.FindGameObjectsWithTag("Civil");     // get all Civils

        if (goalLocations.Length != 0)  // if still civils alive
        {
            foreach (GameObject o in goalLocations)
            {
                float dist = Vector3.Distance(o.transform.position, currentPos);
                if (dist < minDist)
                {
                    oMin = o;
                    minDist = dist;
                }
            }
            //agent.SetDestination(oMin.transform.position);
        }
        else
        {
            Debug.Log("ZERO GOAL");
        }

        return oMin;
    }
}
