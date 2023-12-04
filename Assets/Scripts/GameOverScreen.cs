using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameText;
    public GameObject GameText2;
    public TMP_Text pointsText;
    public TMP_Text highScoreText;
    public void Setup(int score){
        gameObject.SetActive(true);
        GameText.SetActive(false);
        GameText2.SetActive(false);

        int highScore = LoadScore();

        pointsText.text = score.ToString() + " Coins";
        highScoreText.text = "Last High Score: " + highScore.ToString();
        
        
        Time.timeScale = 0f;
    }

    int LoadScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
