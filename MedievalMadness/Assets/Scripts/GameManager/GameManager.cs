using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;          // implement when killing monster
    private int civilCount;         // number of civil alive

    public GameObject player;       // player
    public Text scoreText;          // Score to print on the screen during playing
    public Text NPCAliveText;       // NPC Alive to print on the screen during playing
    public DefeatMenu endScreen;    // end screen to show at the end
    private AudioSource audiosource;      // end audio
    public int waveCompteur;        // wave count
    public bool MonsterFromPreviousWaveSpawned = true;  
    public bool spawnable = false;
    public GameObject audioManager;
    private GameObject spawnPointChoosed;

    public GameObject[] spawnPoint; // array of spawn points
    public GameObject[] Monsters;   // array of monster
    public GameObject[] arrows;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        civilCount = GameObject.FindGameObjectsWithTag("Civil").Length;     // get the number of Civil
        waveCompteur = 0;                                                   // set wave count to 0
        Debug.Log("Number of spawn = " + spawnPoint.Length);
    }

    private void Update()
    {
        this.scoreText.text = this.score.ToString();            // update score on screen
        this.NPCAliveText.text = this.civilCount.ToString();    // update npc alive on screen

        //lanceur de nouvelle vague
        if (GameObject.FindGameObjectsWithTag("Monster").Length == 0)    // if still no monster
        {
            waveCompteur += 1;      // implement wave count
            Debug.Log(waveCompteur);
            int choiceSpawn = Random.Range(0, spawnPoint.Length -1 );
            this.spawnPointChoosed = spawnPoint[choiceSpawn];
            //to spawn arrow to indicate where monsters spawn
            arrows[choiceSpawn].SetActive(true);
            Invoke("RemoveArrow",4);

            for(int i = 0; i < waveCompteur ; i ++)
            {
                float timeToWaitBeforeSpawn = (float)i /2;
                Invoke("SpawnMonster", timeToWaitBeforeSpawn);   // spawn monster
            }

               
        }
        
    }


    //to remove arrow
    public void RemoveArrow()
    {
        arrows[0].SetActive(false);
        arrows[1].SetActive(false);
        arrows[2].SetActive(false);
        arrows[3].SetActive(false);
        arrows[4].SetActive(false);
        arrows[5].SetActive(false);
    }
    // spawn monster
    private void SpawnMonster()
    {
        // Get random spawn Point
        
        // Spawn Big Monster
        Instantiate(Monsters[2], this.spawnPointChoosed.transform);

        
        // spawn small monster
        Instantiate(Monsters[0], this.spawnPointChoosed.transform);
        Instantiate(Monsters[0], this.spawnPointChoosed.transform);
        Instantiate(Monsters[0], this.spawnPointChoosed.transform);
        Instantiate(Monsters[0], this.spawnPointChoosed.transform);
        

        // Spawn Normal Monster
        Instantiate(Monsters[1], this.spawnPointChoosed.transform);
        Instantiate(Monsters[1], this.spawnPointChoosed.transform);
        

        
        MonsterFromPreviousWaveSpawned = true;
    }


    // update score after killing monster
    public void AddScore(int score)
    {
        if (player.GetComponent<Player>().isMadness)   // if the player is in madness mode
        {
            this.score += score * 2;
        }
        else
        {
            this.score += score ;
        }
    }


    // when civil dies
    public void civilDead()
    {
        civilCount-=1;  // decrement count of civil

        if(civilCount <= 0) // if no more civil
        {
            EndGame();  // stop the game
        }
    }

    private void EndGame()
    {
        audioManager.GetComponent<AudioSource>().Stop();
        audiosource.Play(0);
        endScreen.ShowDefeatMenu(score);    // show end screen with score
    }

}
