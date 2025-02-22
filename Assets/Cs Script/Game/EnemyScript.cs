using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private PlayerScript playerSc;
    private LogicManger logic;
    public GameObject EnemyEffect;    
    public float EnemySpeed; // Speed of the enemy
    public float targetScore = 10;
    private Text score;

    [ContextMenu("Inheres Score")]
    
    void Start()
    {
        // Find the player and LogicManger objects
        playerSc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManger>();
        score = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
    }

    void Update()
    {
        if (playerSc.CanPlay)
        {    
            // Calculate the direction towards the player
            Vector3 direction = (playerSc.transform.position - transform.position).normalized;
            // Move the enemy towards the player
            transform.position += direction * EnemySpeed * Time.deltaTime;

            if (playerSc.PlayerScore > targetScore)
            {
                EnemySpeed += 1;
                targetScore += 10;
            }
        }
    }

    // Handle collision with bullets
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Destroy the enemy and the bullet
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(EnemyEffect, transform.position, Quaternion.identity);
            logic.IntAdd(ref playerSc.PlayerScore, 1);
            score.text = $"{playerSc.PlayerScore.ToString()}";
        }
    }
}