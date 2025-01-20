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
    public void PlayerAcceleration(ref float planeSpeed, ref float rotSpeed)
    {
        // Check if the player is speeding up
        bool isSpeeding = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.UpArrow)) && Player.CanPlay;
        // Check if the player is slowing down
        bool isSlowing = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && Player.CanPlay;

        if (isSpeeding)
        {
            // Double the speed if speeding up
            planeSpeed = BaseSpeed * 2;
            rotSpeed = BaseRotSpeed * 1.5f;

        }
        else if (isSlowing)
        {
            // Halve the speed if slowing down
            planeSpeed = BaseSpeed / 2;
            rotSpeed = BaseRotSpeed;
        }
        else
        {
            // Gradually return to base speed
            planeSpeed = Mathf.Lerp(planeSpeed, BaseSpeed, Time.deltaTime * 5);
            rotSpeed = Mathf.Lerp(rotSpeed, BaseRotSpeed, Time.deltaTime * 5);
        }
    }
    // Function to rotate the player
    public void PlayerRotate(float RotateSpeed)
    {
        // Rotate left if the Left Arrow or 'A' key is pressed
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Player.CanPlay)
        {
            transform.Rotate(new Vector3(0, 0, 1) * RotateSpeed * Time.deltaTime);
        }

        // Rotate right if the Right Arrow or 'D' key is pressed
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Player.CanPlay)
        {
            transform.Rotate(new Vector3(0, 0, -1) * RotateSpeed * Time.deltaTime);
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