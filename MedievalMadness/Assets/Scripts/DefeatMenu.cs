using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DefeatMenu : MonoBehaviour
{
 public static bool GameIsPaused = false;

    public GameObject DefeatMenuUI; 
    public TextMeshProUGUI ScoreUI;


    public void ShowDefeatMenu(int score){
        
        ScoreUI.text = score.ToString();
        DefeatMenuUI.SetActive(true);
        Time.timeScale = 0.0f;

        GameIsPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu"); 
    }

}
