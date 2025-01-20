using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public PlayerSpeed Speed; // Reference to the PlayerSpeed script for speed management
    public PlayerHealth health; // Reference to the PlayerHealth script for health management
    public PlayerArea Area; // Reference to the PlayerArea script for boundary clamping
    public LogicManger Logic; // Reference to the LogicManger script for game logic
    public EnemyScript Enemy; // Reference to the EnemyScript script for enemy interaction
    public int PlayerScore = 0; // Player's score
    public bool CanPlay = true; // Flag to check if the player can play
    public bool startGame = false; // Flag to start the game

    void Start()
    {
        transform.position = new Vector3(0, -3, 0); // Set the initial position of the player
    }
    void Update()
    {
        // Move the player forward based on PlaneSpeed
        // Start the game if any key is pressed or startGame is true
        if ((Input.anyKeyDown || startGame) && CanPlay)
        {
            startGame = true;
            PlayerMove();
            // Update speed and rotation
            Speed.PlayerAcceleration(ref Speed.PlaneSpeed, ref Speed.RotSpeed);
            Speed.PlayerRotate(Speed.RotSpeed);
        }

        
        // Clamp the player's position within the defined boundaries
        Area.ClampPosition();
    }

    // Function to move the player
    public void PlayerMove()
    {
        transform.Translate(Vector3.up * Speed.PlaneSpeed * Time.deltaTime);
    }


    // Handle collision with enemies
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Trigger death sequence
            health.Dead(2.5f);
            // Reduce player speed
            Speed.AccelerationSpeed(ref Speed.PlaneSpeed, -1);
            // Reduce enemy speed
            Speed.AccelerationSpeed(ref Enemy.EnemySpeed, -0.5f);
            // Delay before stopping the game
            // Stop the player from playing
            CanPlay = false;
        }
    }
}