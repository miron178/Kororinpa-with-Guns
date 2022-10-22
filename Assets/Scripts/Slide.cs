using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    [SerializeField]
    float maxVelocity = 0f;

    [SerializeField]
    private GameObject gun = null;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float m_maxAngle = 45f;

    [SerializeField]
    GameObject m_camera = null;

    [SerializeField]
    float m_cameraAngleSmoothSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //turn on gyro
        Input.gyro.enabled = true;
        //stop screen rotating
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //stop screen sleeping
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (maxVelocity <= 0)
        {
            Debug.LogError("need MaxSpeed <= 0");
        }
        if (gun = null)
        {
            Debug.LogWarning("Remember to add gun");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.gravity = Down() * 9.81f;

        /*
        cap speed
        */
    }

    protected void OnGUI()
    {
        //GUI.skin.label.fontSize = Screen.width / 40;

        //GUILayout.Label("Orientation: " + Screen.orientation);
        //GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        //GUILayout.Label("input.acceleration: " + Input.acceleration);
        //GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);

        //GUILayout.Label("Input.gyro.attitude.eulerAngles: " + Input.gyro.attitude.eulerAngles);
        //GUILayout.Label("Down: " + Down());
        //GUILayout.Label("Physics.gravity: " + Physics.gravity);
    }

    Vector3 Down()
    {
        // Phone down vector (ignoring z copordinate)
        Vector3 down = Input.acceleration;
        down.z = 0f;

        // Rotation from unity down to my down
        Quaternion rotation = Quaternion.FromToRotation(Vector3.down, down);

        //clamp
        float angle = rotation.eulerAngles.z;
        if (angle >= 180)
        {
            angle -= 360;
        }
        float clamped = Mathf.Clamp(angle, -m_maxAngle, m_maxAngle);

        float cameraAngle = m_camera.transform.eulerAngles.z;
        if (cameraAngle >= 180)
        {
            cameraAngle -= 360;
        }
        float smooth = Mathf.Lerp(cameraAngle, clamped - angle, m_cameraAngleSmoothSpeed * Time.deltaTime);
        m_camera.transform.eulerAngles = new Vector3(0f, 0f, smooth);
        Debug.Log("a=" + angle + ", c=" + clamped + ", d=" + (clamped - angle) + ", z=" + cameraAngle + ", dt=" + Time.deltaTime);

        // Clamped rotation
        down = Quaternion.Euler(0, 0, clamped) * Vector3.down;

        //debug draw
        Debug.DrawLine(transform.position, transform.position+down, Color.red);
        return down;
    }


    /*
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
    */
}
