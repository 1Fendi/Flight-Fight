using UnityEngine;
using System;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public LogicManger Logic; // Reference to the LogicManger script
    public int MaxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player

    void Start()
    {
        // Initialize current health to max health
        currentHealth = MaxHealth;
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
            Dead(2.5f);
        }
    }

    // Function to handle player death
    public void Dead(float sec)
    {
        StartCoroutine(DeadTitles(sec));
        // Restart the game if 'W' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Logic.restart();
        }
        // Go to the main menu if 'S' is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Logic.ToMainMenu();
        }
    }

    public IEnumerator DeadTitles(float sec)
    {
        yield return Logic.StartCoroutine(Logic.SecDelay(sec, Logic.GameOver));
        yield return Logic.StartCoroutine(Logic.SecDelay(sec - 1.5f, Logic.PlayAgainButton));
        yield return Logic.StartCoroutine(Logic.SecDelay(sec - 1.5f, Logic.MainMenuButton));
        
    }
}