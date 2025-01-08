using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int BaseSpeed = 10;
    public float RotSpeed = 100f;
    //Change this to private if you don't want to see it in the inspector
    public int PlaneSpeed;

    // Just add colliders to the borders (AKA Invisible Walls)
    public float MinX = -10f;
    public float MaxX = 10f;
    public float MinY = -5f;
    public float MaxY = 5f;

    void Start()
    {
        PlaneSpeed = BaseSpeed;
    }

    void Update()
    {
        // تحريك الطائرة للأمام
        transform.Translate(Vector3.up * PlaneSpeed * Time.deltaTime);

        // تحديث السرعة والدوران
        PlayerSpeed();
        PlayerRotate(RotSpeed);

        // منع الخروج عن الحدود
        ClampPosition();
    }

    void PlayerSpeed()
    {
        bool isSpeeding = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.UpArrow);
        bool isSlowing = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        if (isSpeeding)
        {
            PlaneSpeed = BaseSpeed * 2;
        }
        else if (isSlowing)
        {
            PlaneSpeed = BaseSpeed / 2;
        }
        else
        {
            PlaneSpeed = BaseSpeed;
        }
    }

    void PlayerRotate(float RotateSpeed)
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1) * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -1) * RotateSpeed * Time.deltaTime);
        }
    }

    void ClampPosition()
    {
        // الحصول على موقع اللاعب الحالي
        Vector3 position = transform.position;

        // تحديد الحدود
        position.x = Mathf.Clamp(position.x, MinX, MaxX);
        position.y = Mathf.Clamp(position.y, MinY, MaxY);

        // تحديث موقع اللاعب
        transform.position = position;
    }
}
