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
    public static bool CanPlay = true; // Flag to check if the player can play
    public bool startGame = false; // Flag to start the game


    void Start()
    {
        // Trigger death sequence
            health.Dead(2.5f);
            // Reduce player speed
            Speed.AccelerationSpeed(ref Speed.PlaneSpeed, -1);
            // Reduce enemy speed
            Speed.AccelerationSpeed(ref Enemy.EnemySpeed, -72);
            // Delay before stopping the game
            Logic.TimeDelay(2);
            // Stop the player from playing
            CanPlay = false;
    }
    void Update()
    {
        // Move the player forward based on PlaneSpeed
        transform.Translate(Vector3.up * Speed.PlaneSpeed * Time.deltaTime);

        // Start the game if any key is pressed or startGame is true
        if ((Input.anyKeyDown || startGame) && CanPlay)
        {
            PlayerMove();
            startGame = true;
        }

        // Update speed and rotation
        Speed.PlayerAcceleration();
        PlayerRotate(Speed.RotSpeed);

        // Clamp the player's position within the defined boundaries
        Area.ClampPosition();
    }

    // Function to move the player
    public void PlayerMove()
    {
        transform.Translate(Vector3.up * Speed.PlaneSpeed * Time.deltaTime);
    }

    // Function to rotate the player
    void PlayerRotate(float RotateSpeed)
    {
        // Rotate left if the Left Arrow or 'A' key is pressed
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && CanPlay)
        {
            transform.Rotate(new Vector3(0, 0, 1) * RotateSpeed * Time.deltaTime);
        }

        // Rotate right if the Right Arrow or 'D' key is pressed
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && CanPlay)
        {
            transform.Rotate(new Vector3(0, 0, -1) * RotateSpeed * Time.deltaTime);
        }
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
            Speed.AccelerationSpeed(ref Enemy.EnemySpeed, -72);
            // Delay before stopping the game
            Logic.TimeDelay(2);
            // Stop the player from playing
            CanPlay = false;
        }
    }
}