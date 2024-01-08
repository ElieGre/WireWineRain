using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public float damageRate = 0.3f;
    private float nextDamageTime;

    void Start()
    {
        // Set the next damage time initially
        nextDamageTime = Time.time + damageRate;
    }

    void Update()
    {
        // Check if it's time to apply damage
        if (Time.time >= nextDamageTime)
        {
            // Check if the player is outside the building
            if (!GetComponent<CollisionTest>().inside)
            {
                // Apply damage
                TakeDamage(1);

                // Set the next damage time
                nextDamageTime = Time.time + damageRate;
            }
        }
    }

    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Handle health-related logic (e.g., update UI, check for death)
        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death logic
        Debug.Log("Player has died!");
    }
}
