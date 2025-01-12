using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f; // Movement speed modifier
    private Camera mainCamera;
    private float halfWidth;

    void Start()
    {
        // Cache the main camera reference
        mainCamera = Camera.main;

        // Calculate half the width of the object based on its scale
        halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
        HandleMovement();
    }

    // Handle horizontal player movement
    private void HandleMovement()
    {
        // Get the horizontal input
        float movement = Input.GetAxis("Horizontal");

        // Update the position based on input, speed, and deltaTime
        Vector3 newPosition = transform.position + new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        // Clamp the new position to stay within the camera view
        newPosition.x = Mathf.Clamp(newPosition.x, GetCameraLeftBound() + halfWidth, GetCameraRightBound() - halfWidth);

        // Apply the clamped position
        transform.position = newPosition;
    }

    // Get the left boundary of the camera in world coordinates
    private float GetCameraLeftBound()
    {
        return mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - mainCamera.transform.position.z)).x;
    }

    // Get the right boundary of the camera in world coordinates
    private float GetCameraRightBound()
    {
        return mainCamera.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z - mainCamera.transform.position.z)).x;
    }
}
