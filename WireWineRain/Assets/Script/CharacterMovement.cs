using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float speedIncrement = 1f;
    private float timeSinceLastIncrement = 0f;

    void Update()
    {
        // Increment speed every 10 seconds
        timeSinceLastIncrement += Time.deltaTime;
        if (timeSinceLastIncrement >= 10f)
        {
            moveSpeed += speedIncrement;
            timeSinceLastIncrement = 0f; // Reset the timer
        }

        // Calculate the movement vector
        Vector3 movement = new Vector3(0f, 0f, 1f);

        // Move the character continuously along the Z-axis
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
