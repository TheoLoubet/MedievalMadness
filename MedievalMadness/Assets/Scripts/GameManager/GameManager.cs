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
    public int waveCompteur;        // wave count
    public bool MonsterFromPreviousWaveSpawned = true;  
    public bool spawnable = false;

    public GameObject[] spawnPoint; // array of spawn points
    public GameObject[] Monsters;   // array of monster
    
    void Start()
    {
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
            if (MonsterFromPreviousWaveSpawned == true)
            {
                waveCompteur += 1;      // implement wave count
                MonsterFromPreviousWaveSpawned = false;
                this.SpawnMonster();    // spawn monster
            }
        }
    }

    // spawn monster
    private void SpawnMonster()
    {
        // Get random spawn Point
        int choiceSpawn = Random.Range(0, spawnPoint.Length -1 );
        GameObject spawnPointChoosed = spawnPoint[choiceSpawn];

        // spawn small monster
        for (int i = 0; i < waveCompteur; i++)
        {
            Instantiate(Monsters[0], spawnPointChoosed.transform);
            Instantiate(Monsters[0], spawnPointChoosed.transform);
            Instantiate(Monsters[0], spawnPointChoosed.transform);
            Instantiate(Monsters[0], spawnPointChoosed.transform);
        }

        // Spawn Normal Monster
        for (int i = 0; i < waveCompteur; i++)
        {
            Instantiate(Monsters[1], spawnPointChoosed.transform);
            Instantiate(Monsters[1], spawnPointChoosed.transform);
        }

        // Spawn Big Monster
        for (int i = 0; i < waveCompteur; i++)
        {
            Instantiate(Monsters[2], spawnPointChoosed.transform);
        }
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
        endScreen.ShowDefeatMenu(score);    // show end screen with score
    }

}
