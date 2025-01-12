using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float MovementSpeed = 1f; // Movement speed modifier

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input
        float movement = Input.GetAxis("Horizontal");

        // Update the position based on input, speed, and deltaTime
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
    }
}
