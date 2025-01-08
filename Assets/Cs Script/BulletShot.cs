using Unity.VisualScripting;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShotPS;

    private float Timer;
    public float restartTime;

    // Use the New Input System Instead
    //skip the importing of the new input system
    //https://youtu.be/HmXU4dZbaMw?si=whUaEMwHClAcah1A&t=147

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Timer <= 0)
        {
            Instantiate(Bullet, ShotPS.position, transform.rotation);
            Timer = restartTime;
        }
        else
        {
            Timer -= Time.deltaTime;
        }

    }
}
