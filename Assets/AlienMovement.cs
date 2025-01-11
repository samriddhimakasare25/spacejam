using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public Rigidbody2D rb;

    void Start()
       
    {

    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0) * speed;

        // Apply the movement to the Rigidbody2D velocity
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

    }
}
