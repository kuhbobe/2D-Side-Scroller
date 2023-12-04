using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    int character;
    public GameObject Rollie;
    public GameObject Bushly;
    public GameObject Devo;
    void Start()
    {
        character = PlayerPrefs.GetInt("selectedCharacter", 0);
        if (character == 0){
            Rollie.SetActive(false);
            Bushly.SetActive(true);
            Devo.SetActive(false);
        } else if (character == 1){
            Rollie.SetActive(true);
            Bushly.SetActive(false);
            Devo.SetActive(false);
        }else if (character == 2){
            Rollie.SetActive(false);
            Bushly.SetActive(false);
            Devo.SetActive(true);
        }
    }

}
