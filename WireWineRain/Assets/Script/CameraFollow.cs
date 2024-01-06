using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's (capsule's) Transform
    public Vector3 offset = new Vector3(0f, 3f, -5f); // Adjust this offset as needed

    void Update()
    {
        if (target != null)
        {
            // Set the camera's position to follow the target with an offset
            transform.position = target.position + offset;
        }
    }
}
