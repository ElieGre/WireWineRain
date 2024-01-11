using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Umbrella umbrella;

    public int maxHealth = 100;
    public int currentHealth;
    public float damageRate = 1f;
    private float nextDamageTime;
    private bool canTakeDamage = true;
    [SerializeField] public GameObject UI;
    

    void Start()
    {
        currentHealth = maxHealth;
        nextDamageTime = Time.time;
    }

void Update()
{
        // Toggle the ability to take damage on left-click
    if (umbrella.GetIsUmbrellaOpen())
    {
        canTakeDamage = false;
        //Debug.Log("Umbrella open. Can take damage: " + canTakeDamage);
    }
    else
    {
        canTakeDamage = true;
    }

    // Assume the CollisionTest script is attached to the player GameObject
    CollisionTest collisionTest = GetComponent<CollisionTest>();

    // Check if both canTakeDamage and inside are true before applying damage
    if ((canTakeDamage && !collisionTest.inside) || (!canTakeDamage && collisionTest.inside))
    {
        // Apply damage
        TakeDamage(1);
    }

    // Other parts of the Update method...
}

void TakeDamage(int damageAmount)
{
    currentHealth -= damageAmount;

    // Add your logic for handling the health reduction, like checking for death, updating UI, etc.
    // Debug.Log("Player took damage! Current health: " + currentHealth);

    // Example: If health drops to 0, destroy the player
    if (currentHealth <= 0)
    {
        Die();
            
    }
}


    void Die()
    {
        UI.SetActive(true);
        // Add your logic for player death
        Debug.Log("Player has died!");

        // Check if the player object exists before attempting to destroy it
        if (gameObject != null)
        {
            Destroy(gameObject); // Destroy the player GameObject
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with an object tagged "EndHouse"
        if (other.CompareTag("EndHouse"))
        {
            Die(); // Destroy the player when colliding with "EndHouse"
        }
    }

    
}
