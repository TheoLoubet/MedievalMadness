using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    private int score = 0;
    private int civilCount;
    public DefeatMenu endScreen;

    void Start()
    {
        civilCount = GameObject.FindGameObjectsWithTag("Civil").Length;
    }

    private void Update()
    {
        this.scoreText.text = this.score.ToString();
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
        civilCount--;
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
