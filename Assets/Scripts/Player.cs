using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip coinSound;
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       Debug.Log(LoadScore());
       livesText.text = "Lives: " + lives.ToString();
       
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = UnityEngine.Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        if(!PauseMenu.Paused){
            if(UnityEngine.Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 10f);
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.CompareTag("Obstacle")){
            GetComponent<AudioSource>().PlayOneShot(hitSound);
            lives--;
            Debug.Log(lives);
            if (lives != 0){ 
                livesText.text = "Lives: " + lives.ToString();
            } else {
                Destroy(gameObject);
                SaveScore();
                SceneManager.LoadScene("Main Menu");
            }
            
        } else if (other.gameObject.CompareTag("Coin"))
        {
            
            GetComponent<AudioSource>().PlayOneShot(coinSound);
            IncreaseScore(); // Increment the score
            Debug.Log("Score: " + score);
            scoreText.text = "Current Score: " + score.ToString();
        }

    }

    void IncreaseScore()
    {
        score++; // Increment the score
        // You can also update the UI to display the current score here, if needed.
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }
    int LoadScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

}
