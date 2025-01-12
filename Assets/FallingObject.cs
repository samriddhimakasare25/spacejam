using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    public float fallSpeed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}






