using UnityEngine;
using UnityEngine.AI;
public class Civil : MonoBehaviour
{
    public GameManager GM;
    public NavMeshAgent agent;
    public float moveSpeedDefault = 3;
    public AudioClip deathSound;        
    public GameObject AudioManager;
    public GameObject madnessBar;


    private void Start() 
    {
        AudioManager = GameObject.Find("AudioDeathCivil");
        madnessBar= GameObject.Find("Madness_Bar");
    }

    private void Awake()
    {
        agent.speed = moveSpeedDefault;
    }

    public void Death()
    {
        madnessBar.GetComponent<MadnessBar>().CivilDeath();
        AudioManager.GetComponent<AudioSource>().PlayOneShot(deathSound,Random.Range(0.1f,0.3f));
        GM.civilDead();
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
