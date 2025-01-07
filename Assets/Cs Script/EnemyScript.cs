using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public int Speed;

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * Speed * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
