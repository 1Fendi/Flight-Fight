using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    public float MaxX; // Maximum X boundary
    
    public float MaxY; // Maximum Y boundary
    

    // Function to clamp the player's position within the defined boundaries
    public void ClampPosition()
    {
        // Get the current position of the player
        Vector3 position = transform.position;

        // Clamp the X and Y positions
        position.x = Mathf.Clamp(position.x, MaxX * -1, MaxX);
        position.y = Mathf.Clamp(position.y, MaxY * -1, MaxY);

        // Update the player's position
        transform.position = position;
    }
}