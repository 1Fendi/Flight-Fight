using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LogicManger Logic; // Reference to the LogicManger script
    public int MaxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player

    void Start()
    {
        // Initialize current health to max health
        currentHealth = MaxHealth;
        // Trigger death sequence after a delay (for testing)
        Dead(2.5f);
    }

    // Function to handle taking damage
    public void TakeDamage(int damage)
    {
        // Reduce health by the damage amount
        currentHealth -= damage;
        // Check if the player is dead
        if (currentHealth <= 0)
        {
            // Trigger death sequence
            Dead(1000);
        }
    }

    // Function to handle player death
    public void Dead(float sec)
    {
        // Delay before showing game over text
        Logic.TimeDelay(sec);
        Logic.gameOverText.enabled = true;

        // Delay before enabling the Play Again button
        Logic.TimeDelay(sec - 1);
        Logic.PlayAgain.enabled = true;

        // Delay before enabling the Main Menu button
        Logic.TimeDelay(sec - 1);
        Logic.MainMenu.enabled = true;

        // Restart the game if 'W' is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            Logic.restart();
        }
        // Go to the main menu if 'S' is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            Logic.ToMainMenu();
        }
    }
}