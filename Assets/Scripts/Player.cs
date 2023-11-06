using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
        }

        SceneManager.LoadScene("Main Menu");

    }

}
