using UnityEngine;
using System.Collections;
public class SpawnPointsScript : MonoBehaviour
{
    public Transform[] Points; // Array of spawn points
    public GameObject Enemy; // Reference to the enemy prefab
    public LogicManger Logic; // Reference to the LogicManger script
    public float spawnTime = 3f; // Delay between enemy spawns
    public float spawnRate = 3f; // Rate of enemy spawns
    public float lowestTime = 1f; // Lowest delay between enemy spawns
    public float highestTime = 5f; // Highest delay between enemy spawns    
    void Update()
    {
        if (spawnTime < spawnRate)
        {
            spawnTime += Time.deltaTime;
            
        }
        else 
        {
            SpawnEnemy(); 
            spawnTime = Random.Range(lowestTime, highestTime);
        }
    }

    public void SpawnEnemy()
    {
        // Randomly select a spawn point
        int randomPoint = Random.Range(0, Points.Length);
        // Delay before spawning an enemy
        Logic.TimeDelay(8);
        // Spawn an enemy at the selected spawn point
        Instantiate(Enemy, Points[randomPoint].position, Quaternion.identity);
        // Delay before spawning the next enemy
        
    }
}