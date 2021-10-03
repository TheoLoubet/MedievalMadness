using UnityEngine;
using UnityEngine.AI;
public class Civil : MonoBehaviour
{
    public NavMeshAgent agent;
    public float moveSpeedDefault = 3;
    public AudioClip deathSound;        
    public GameObject AudioManager;


    private void Awake()
    {
        agent.speed = moveSpeedDefault;
    }

    public void Death()
    {

        AudioManager.GetComponent<AudioSource>().PlayOneShot(deathSound,Random.Range(0.1f,0.3f));
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
