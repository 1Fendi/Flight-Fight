using UnityEngine;

public class MenuPlayerScript : MonoBehaviour
{
    public PlayerArea area; // Reference to the PlayerArea script for boundary clamping
    public bool startPlay = false; // Flag to start/stop player movement
    public float move = 5; // Movement speed of the player

    void Update()
    {
        // Toggle startPlay when the "/" key is pressed
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            startPlay = !startPlay; // Toggle between true and false
            move = startPlay ? 5 : 0; // Set move to 5 if startPlay is true, otherwise set it to 0
        }

        // Move the player if startPlay is true
        if (startPlay)
        {
            PlayerMove();
        }

        // Rotate the player
        PlayerRotate(180);

        // Clamp the player's position within the defined boundaries
        area.ClampPosition();
    }

    // Function to move the player
    public void PlayerMove()
    {
        transform.Translate(Vector3.up * move * Time.deltaTime);
    }

    // Function to rotate the player
    void PlayerRotate(float RotateSpeed)
    {
        // Rotate left if the Left Arrow or 'A' key is pressed
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1) * RotateSpeed * Time.deltaTime);
        }

        // Rotate right if the Right Arrow or 'D' key is pressed
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -1) * RotateSpeed * Time.deltaTime);
        }
    }
}