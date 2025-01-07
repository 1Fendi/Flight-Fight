using Unity.VisualScripting;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShotPS;

    private float Timer;
    public float restartTime;

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
