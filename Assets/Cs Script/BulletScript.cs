using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int Speed;
    public double boundary = 15;
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > boundary || Mathf.Abs(transform.position.y) > boundary)
        {
            Destroy(gameObject);
        }
    }
}
