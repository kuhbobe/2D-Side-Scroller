using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text pointsText;
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Coins";
    }
}
