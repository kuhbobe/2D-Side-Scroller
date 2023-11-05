using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused) { 
                Play();
            } else {
                Stop();
            }
        }
    }

    void Stop(){
        Debug.Log("Pause menu stopped");
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play(){
        Debug.Log("Pause menu started");
        PauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            Paused = false;
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("Main Menu");
    }
}
