using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject Bullet; // Reference to the bullet prefab
    public Transform ShotPS; // Reference to the shot position transform
    private float Timer; // Timer for shooting cooldown
    public float restartTime; // Cooldown time between shots

    void Update()
    {
        // Check if the player can shoot
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && Timer <= 0)
        {
            // Instantiate a bullet at the shot position
            Instantiate(Bullet, ShotPS.position, transform.rotation);
            // Reset the timer
            Timer = restartTime;
        }
        else
        {
            // Decrease the timer
            Timer -= Time.deltaTime;
        }
    }
}