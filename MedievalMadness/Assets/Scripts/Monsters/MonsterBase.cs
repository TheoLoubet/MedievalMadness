using UnityEngine;
using UnityEngine.AI;

public class MonsterBase : MonoBehaviour
{
    public AudioClip monsterDeathSound;
    public GameObject AudioManager;
    public NavMeshAgent agent;

    public float healthPoint;
    public float moveSpeedDefault = 5;
    
    private void Awake()
    {
        agent.speed = moveSpeedDefault;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Civil"))
        {
            collision.gameObject.GetComponent<Civil>().Death();
        }
    }

    public void TakeDamage(float damage)
    {
        this.healthPoint -= damage;
        if (this.healthPoint <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        AudioManager.GetComponent<AudioSource>().PlayOneShot(monsterDeathSound,1f);
        Destroy(this.gameObject);
    }

    public void Slow(float power)
    {
        agent.speed = agent.speed * power;
    }
    public void UnSlow()
    {
        agent.speed = moveSpeedDefault;
    }
}
