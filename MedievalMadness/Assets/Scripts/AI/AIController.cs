using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    float speedMult;
    public float fleeRadius = 3;
    public float speedFlee = 3;
    private Rigidbody2D rb;

    void ResetAgent()
    {
        speedMult = Random.Range(0.5f, 1f);
        agent.speed = 2 * speedMult;
        agent.angularSpeed = 120;
        agent.ResetPath();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        Vector3 randomPosition = goalLocations[Random.Range(0,goalLocations.Length)].transform.position;
        agent.SetDestination(randomPosition);

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
            Vector3 randomPosition = goalLocations[Random.Range(0,goalLocations.Length)].transform.position;
            agent.SetDestination(randomPosition);
        }
        // Rotate civil
        
    }

    private void LookAt(Vector3 goal)
    {
        Vector2 goalToLookAt = new Vector2(goal.x, goal.y);
    }

    //called when a monster is too close
    public void Fleeing(Vector3 position)
    {
        Vector3 fleeDirection = (this.transform.position - position).normalized;
        Vector3 newgoal = this.transform.position + fleeDirection * fleeRadius;
        agent.SetDestination(newgoal);
        agent.speed = speedFlee;
        agent.angularSpeed = 300;
    }

   
}
