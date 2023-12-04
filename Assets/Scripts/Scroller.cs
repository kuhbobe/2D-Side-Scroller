using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public BoxCollider2D collide;
    public Rigidbody2D rb;
    public GameObject Coin;

    private float width;
    private float scrollSpeed = -4f;
    private float minimumDistanceThreshold = 3f;

    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collide.size.x;
        collide.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
        ObstacleReset();
        CoinReset();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ObstacleReset();
            CoinReset();
        
        }
    }

    void ObstacleReset()
{
    // Get the obstacle's transform
    Transform obstacleTransform = transform.GetChild(0);

    // Set a flag to check if the positions overlap
    bool positionsOverlap = true;

    // Repeat until the positions do not overlap
    while (positionsOverlap)
    {
        // Generate a new random position
        Vector3 newPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);

        // Check the distance between the new position and coin's position
        float distanceToCoin = Vector3.Distance(newPosition, transform.GetChild(1).localPosition);

        // Check if the distance is greater than a certain threshold
        if (distanceToCoin > minimumDistanceThreshold)
        {
            // If the distance is acceptable, set the new position and break out of the loop
            obstacleTransform.localPosition = newPosition;
            positionsOverlap = false;
        }
        // If the distance is not acceptable, repeat the loop to generate a new position
    }
}

void CoinReset()
{
    // Get the coin's transform
    Transform coinTransform = transform.GetChild(1);

    // Set a flag to check if the positions overlap
    bool positionsOverlap = true;

    // Repeat until the positions do not overlap
    while (positionsOverlap)
    {
        // Generate a new random position
        Vector3 newPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);

        // Check the distance between the new position and obstacle's position
        float distanceToObstacle = Vector3.Distance(newPosition, transform.GetChild(0).localPosition);

        // Check if the distance is greater than a certain threshold
        if (distanceToObstacle > minimumDistanceThreshold)
        {
            // If the distance is acceptable, set the new position and break out of the loop
            coinTransform.localPosition = newPosition;

            // Show the coin
            Coin.SetActive(true);
            positionsOverlap = false;
        }
        // If the distance is not acceptable, repeat the loop to generate a new position
    }
}

}
