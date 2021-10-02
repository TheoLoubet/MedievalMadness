using UnityEngine;
using UnityEngine.AI;

public class Civil : MonoBehaviour
{
    public NavMeshAgent agent;
    public float moveSpeedDefault = 3;

    private void Awake()
    {
        agent.speed = moveSpeedDefault;
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    public void SpeedUp(float power)
    {
        agent.speed = agent.speed * power;
    }

    public void SpeedDown()
    {
        agent.speed = moveSpeedDefault;
    }


}
