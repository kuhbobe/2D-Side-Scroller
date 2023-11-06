using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public BoxCollider2D collide;
    public Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collide.size.x;
        collide.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
        ObstacleReset();
        StartCoroutine(CoinReset());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }

    void ObstacleReset()
    {
        transform.GetChild(0).localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
    }

    IEnumerator CoinReset()
    {
        // Delay for resetting the coin, you can set your desired time here.
        yield return new WaitForSeconds(2f);

        // Reset the coin's position
        transform.GetChild(1).localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);

        // Show the coin
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
