using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    private int score = 0;
    private int civilCount;
    
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
            Debug.Log("perdu");
        }
    }

}
