using UnityEngine;
using System.Collections;
using System;

public class PlayerSpeed : MonoBehaviour
{
    public PlayerScript Player; // Reference to the PlayerScript
    public float PlaneSpeed; // Current speed of the plane
    public float RotSpeed; // Rotation speed of the plane
    private float BaseSpeed; // Base speed of the plane
    private float BaseRotSpeed;
    private bool mouseRotate = false;

    void Start()
    {
        // Initialize BaseSpeed with the initial PlaneSpeed
        BaseSpeed = PlaneSpeed;
        BaseRotSpeed = RotSpeed;
    }

    public void PlayerMove(float moveSpeed)
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    // Function to handle player acceleration and deceleration
    public void PlayerAcceleration(ref float planeSpeed, ref float rotSpeed)
    {
        // Check if the player is speeding up
        bool isSpeeding = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Mouse1)) && Player.CanPlay;
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
            mouseRotate = false;
        }

        // Rotate right if the Right Arrow or 'D' key is pressed
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Player.CanPlay)
        {
            transform.Rotate(new Vector3(0, 0, -1) * RotateSpeed * Time.deltaTime);
            mouseRotate = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || mouseRotate)
        {
            StartCoroutine(FollowMouseDelay());
            mouseRotate = true;
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

    
public Vector3 lastMousePosition; // مكان الماوس السابق// سرعة حركة اللاعب للأعلى إذا لم يتحرك الماوس
public IEnumerator FollowMouseDelay()
    {
        Vector3 mousePS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePS.z = transform.position.z; // التأكد من أن Z في نفس المستوى

        // تحقق إذا كان الماوس لم يتحرك
        if (mousePS == lastMousePosition)
        {
            // إذا لم يتحرك الماوس، تحرك للأعلى
            transform.Translate(Vector3.up.normalized * PlaneSpeed * Time.deltaTime);
        }
        else
        {
            // إذا تحرك الماوس، قم بتحديث مكانه
            Vector2 direction = new Vector2(mousePS.x - transform.position.x, mousePS.y - transform.position.y);
            direction.Normalize();
            transform.up = direction; // توجه نحو الماوس
        }

        // تحديث مكان الماوس السابق
        yield return Player.Logic.StartCoroutine(Player.Logic.SecDelay(1.5f, () => lastMousePosition = mousePS));
    }
}