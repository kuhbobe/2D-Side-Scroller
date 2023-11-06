using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text highScoreText; // Reference to the Text component where you want to display the high score
    
    void Start()
    {
        int highScore = LoadScore();
        highScoreText.text = "Last Coin Score: " + highScore.ToString();
    }

    int LoadScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
