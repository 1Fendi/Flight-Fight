using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    public float EnemySpeed; // Speed of the enemy

    void Start()
    {
        // Find the player and LogicManger objects
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        // Move the enemy towards the player
        transform.position += direction * EnemySpeed * Time.deltaTime;
    }

    // Handle collision with bullets
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Destroy the enemy and the bullet
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}