using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    private int score = 0;
    private int civilCount;
    public DefeatMenu endScreen;

    public int waveCompteur;
    public bool enable = true;
    public bool spawnable = false;
    public GameObject[] spawnPoint;
    public GameObject[] Monsters;
    
    void Start()
    {
        civilCount = GameObject.FindGameObjectsWithTag("Civil").Length;
        waveCompteur = 0;
        
    }

    private void Update()
    {
        this.scoreText.text = this.score.ToString();


        //lanceur de nouvelle vague
        if(GameObject.FindGameObjectsWithTag("Monster").Length == 0)
        {
            if (enable == true)
            {
                waveCompteur += 1;
                enable = false;
                this.SpawnMonster();
            }
        }
    }


    private void SpawnMonster()
    {
        int choiceSpawn = Random.Range(0,3);
        GameObject spawnPointChoosed = spawnPoint[choiceSpawn];
        for (int i = 0; i < waveCompteur; i++)
        {
            Instantiate(Monsters[0], spawnPointChoosed.transform);
            Instantiate(Monsters[0], spawnPointChoosed.transform);
            Instantiate(Monsters[0], spawnPointChoosed.transform);
            Instantiate(Monsters[0], spawnPointChoosed.transform);
        }
        for (int i = 0; i < waveCompteur; i++)
        {
            Instantiate(Monsters[1], spawnPointChoosed.transform);
            Instantiate(Monsters[1], spawnPointChoosed.transform);
        }
        for (int i = 0; i < waveCompteur; i++)
        {
            Instantiate(Monsters[2], spawnPointChoosed.transform);
        }
        enable = true;
    }


    public void AddScore(int score)
    {
        if (!player.GetComponent<Player>().isMadness)
        {
            this.score += score;
        }
        else
        {
            this.score += score * 2;
        }
    }

    public void civilDead()
    {
        civilCount-=1;
        if(civilCount <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        endScreen.ShowDefeatMenu(score);
    }

}
