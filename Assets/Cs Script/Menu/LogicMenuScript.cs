using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicMenuScript : MonoBehaviour
{
    public GameObject Title; // Reference to the title UI element
    public GameObject Play; // Reference to the play button UI element
    public GameObject Player; // Reference to the player object

    // Function to start the game
    public void ToPlay()
    {
        // Hide the title and play button
        Title.SetActive(false);
        Play.SetActive(false);
        // Destroy the menu logic object
        gameObject.SetActive(false);
        // Load the game scene
        SceneManager.LoadScene(1);
    }
}