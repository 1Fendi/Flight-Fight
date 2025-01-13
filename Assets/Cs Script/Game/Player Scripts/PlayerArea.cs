using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    public float MinX = -9f; // Minimum X boundary
    public float MaxX = 9f; // Maximum X boundary
    public float MinY = -4f; // Minimum Y boundary
    public float MaxY = 4f; // Maximum Y boundary

    // Function to clamp the player's position within the defined boundaries
    public void ClampPosition()
    {
        // Get the current position of the player
        Vector3 position = transform.position;

        // Clamp the X and Y positions
        position.x = Mathf.Clamp(position.x, MinX, MaxX);
        position.y = Mathf.Clamp(position.y, MinY, MaxY);

        // Update the player's position
        transform.position = position;
    }
}