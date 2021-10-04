using UnityEngine;
using UnityEngine.AI;
public class Civil : MonoBehaviour
{
    public GameManager GM;                  // Game Manager
    public NavMeshAgent agent;              // navMeshAgent for movement

    public float moveSpeedDefault = 3;      // speed of civil

    public AudioClip deathSound;            // sound to play when hi dies
    public GameObject AudioManager;         // audio manager

    public GameObject madnessBar;           // link to the madness bar to increase

    private bool isDead = false;            // insure civil dies only once
        


    private void Start() 
    {
        AudioManager = GameObject.Find("AudioDeathCivil");  // access to the Audio manager
        if(!AudioManager) { Debug.Log("ERROR, NO AUDIO MANAGER IN CIVILS"); }

        madnessBar= GameObject.Find("Madness_Bar");         // access to the Madness bar
        if (!madnessBar) { Debug.Log("ERROR, NO MADNESS BAR IN CIVILS"); }

    }

    private void Awake()
    {
        agent.speed = moveSpeedDefault;     // set speed
    }

    public void Death()
    {
        if (!isDead)
        {
            isDead = true;
            madnessBar.GetComponent<MadnessBar>().CivilDeath();                                             // notify to MadnessBar that a Civil is dead
            AudioManager.GetComponent<AudioSource>().PlayOneShot(deathSound, Random.Range(0.1f, 0.3f));       // play death sound
            GM.civilDead();                                                                                 // notify that the civil is dead
            Destroy(this.gameObject);
        }

    }

    public void SpeedUp(float power)
    {
        agent.speed = agent.speed * power;  // increase the speed of the civil
    }

    public void SpeedDown()
    {
        agent.speed = moveSpeedDefault;     // decrease the spee of the civil
    }


}
