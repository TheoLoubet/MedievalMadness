using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Vector3 currentPos;
    private Rigidbody2D rb;
    //Start is called at Start
    private void Start() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        agent = this.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
		agent.updateUpAxis = false;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        GameObject oMin = null;
        float minDist = 100;
        currentPos = transform.position;
        goalLocations = GameObject.FindGameObjectsWithTag("Civil");
        if (goalLocations.Length != 0)
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
        }

        // Rotate monster
        Vector3 direction = agent.velocity.normalized;
        float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        float currentAngle = rb.rotation;
        currentAngle = Mathf.LerpAngle(currentAngle,endAngle,0.3f);
        rb.rotation = currentAngle;
    }
}
