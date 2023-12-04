using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame(){
    SceneManager.LoadScene("Character Selection");
    PauseMenu.Paused = false;

  }

  public void quitGame(){
    Application.Quit();
  }

  public void RestartGame(){
    SceneManager.LoadScene("Game_01");
    PauseMenu.Paused = false;

  }
}
