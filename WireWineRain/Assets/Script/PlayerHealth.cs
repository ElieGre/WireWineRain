using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject timmy;
    [SerializeField] Umbrella umbrella;
    public CharacterMovement timmySpeed;
    public int maxHealth = 10000;
    public int currentHealth;
    private bool canTakeDamage = true;
    [SerializeField] GameObject UI;
    [SerializeField] Slider healthBarSlider;

    // Flag to track whether the scene should be reloaded
    private bool shouldReloadScene = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // Toggle the ability to take damage on left-click
        if (umbrella.GetIsUmbrellaOpen())
        {
            canTakeDamage = false;
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

        // Check if the UI is active and the player has died
        if (UI.activeSelf && shouldReloadScene)
        {
            // Reload the scene when the 'P' key is pressed
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Example: If health drops to 0, call Die() to handle player death
        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Update the Slider value based on the player's health
        healthBarSlider.value = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        // Add your logic for player death
        Debug.Log("Player has died!");
        timmySpeed.moveSpeed = 0f;
        timmySpeed.speedIncrement = 0f;
        Destroy(timmy);
        // Set the flag to indicate that the scene should be reloaded
        shouldReloadScene = true;

        // Activate UI after the player has died
        UI.SetActive(true);
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
