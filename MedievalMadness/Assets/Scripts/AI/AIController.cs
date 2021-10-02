using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    float speedMult;
    float fleeRadius = 8;

    void ResetAgent()
    {
        speedMult = Random.Range(0.5f, 1.5f);
        agent.speed = 2 * speedMult;
        agent.angularSpeed = 120;
        agent.ResetPath();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
        ResetAgent();
        agent.updateRotation = false;
		agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
        }
    }

    //called when a monster is too close
    public void Fleeing(Vector3 position)
    {
        print(position);
        Vector3 fleeDirection = (this.transform.position - position).normalized;
        Vector3 newgoal = this.transform.position + fleeDirection * fleeRadius;
        
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(newgoal, path);

        if(path.status != NavMeshPathStatus.PathInvalid)
        {
            agent.SetDestination(path.corners[path.corners.Length -1]);
            agent.speed = 10;
            agent.angularSpeed = 500;
        }
    }

   
}
