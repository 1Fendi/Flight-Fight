using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int Speed; // Speed of the bullet
    public float boundaryX; // X boundary for the bullet
    public float boundaryY; // Y boundary for the bullet

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.up * Speed * Time.deltaTime);

        // Destroy the bullet if it goes out of bounds
        if (Mathf.Abs(transform.position.x) > boundaryX || Mathf.Abs(transform.position.y) > boundaryY)
        {
            Destroy(gameObject);
        }
    }
}