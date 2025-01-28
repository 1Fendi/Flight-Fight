using UnityEngine;
using System;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public LogicManger Logic; // Reference to the LogicManger script
    public PlayerScript player;
    public GameObject PlayerEffect;

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
        yield return Logic.StartCoroutine(Logic.SecDelay(sec - 1.5f, () => player.gameObject.GetComponent<SpriteRenderer>().enabled = false));
        yield return Instantiate(PlayerEffect, transform.position, Quaternion.identity);
    }
}