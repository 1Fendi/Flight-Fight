using UnityEngine;
public class SpawnPointsScript : MonoBehaviour
{
    public Transform[] Points; // Array of spawn points
    public GameObject Enemy; // Reference to the enemy prefab
    public LogicManger Logic; // Reference to the LogicManger script
    public float SpawnRate; // Rate at which enemies spawn
    public float SpawnDelay; // Delay before the first spawn
    public bool isSpawning = false; // Flag to check if an enemy is currently spawning

    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            Logic.StartTimeDelay(SpawnDelay, SpawnRate, StartSpawning);
        }
    }

    public void StartSpawning()
    {   
        SpawnEnemy();
        isSpawning = false;
    }

    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, Points.Length); // Get a random index
        Transform spawnPoint = Points[randomIndex];
        Instantiate(Enemy, spawnPoint.position, Quaternion.identity); // Spawn the enemy
    }
}