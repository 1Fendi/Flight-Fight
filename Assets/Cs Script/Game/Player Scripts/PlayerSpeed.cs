using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour
{
    public PlayerScript Player; // Reference to the PlayerScript
    public float PlaneSpeed; // Current speed of the plane
    public float RotSpeed; // Rotation speed of the plane
    private float BaseSpeed; // Base speed of the plane
    private float BaseRotSpeed;

    void Start()
    {
        // Initialize BaseSpeed with the initial PlaneSpeed
        BaseSpeed = PlaneSpeed;
        BaseRotSpeed = RotSpeed;
    }

    // Function to handle player acceleration and deceleration
    public void PlayerAcceleration()
    {
        // Check if the player is speeding up
        bool isSpeeding = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.UpArrow)) && PlayerScript.CanPlay;
        // Check if the player is slowing down
        bool isSlowing = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && PlayerScript.CanPlay;

        if (isSpeeding)
        {
            // Double the speed if speeding up
            PlaneSpeed = BaseSpeed * 2;
            RotSpeed = BaseRotSpeed * 1.5f;

        }
        else if (isSlowing)
        {
            // Halve the speed if slowing down
            PlaneSpeed = BaseSpeed / 2;
            RotSpeed = BaseRotSpeed;
        }
        else
        {
            // Gradually return to base speed
            PlaneSpeed = Mathf.Lerp(PlaneSpeed, BaseSpeed, Time.deltaTime * 5);
            RotSpeed = Mathf.Lerp(RotSpeed, BaseRotSpeed, Time.deltaTime * 5);
        }
    }

    // Function to adjust speed based on acceleration
    public float AccelerationSpeed(ref float fSpeed, float Acceleration)
    {
        // Adjust speed based on acceleration
        fSpeed += Acceleration * Time.deltaTime;

        // Ensure speed doesn't go below 0
        if (fSpeed < 0)
        {
            fSpeed = 0;
        }

        return fSpeed;
    }
}