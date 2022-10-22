using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float m_clipSize = 0;
    [SerializeField]
    float m_recoil = 0;
    [SerializeField]
    float m_damage = 0;
    [SerializeField]
    float m_bulletLifeTime = 0;

    [SerializeField]
    Rigidbody2D m_rb;

    int gunType = 0;
    void GunType()
    {
        switch (gunType)
        {
            case 1: // pistol
                break;
            case 2: //shotgun
                break;
            case 3: //rocket luncher
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
                Fire(position);
            }
        }    
    }

    private void Fire(Vector3 target)
    {
        Debug.DrawLine(transform.position, target, Color.white, 1.0f);

        Vector3 recoil = (transform.position - target).normalized * m_recoil;
        //Debug.DrawRay(transform.position, recoil, Color.yellow, 1.0f);
        m_rb.AddForce(recoil);
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            GUILayout.Label("Touch phase: " + touch.phase);
            GUILayout.Label("Touch screen position: " + touch.position);
            GUILayout.Label("Touch world position: " + Camera.main.ScreenToWorldPoint(touch.position));
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.lossyScale);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(Camera.main.ScreenToWorldPoint(touch.position), transform.lossyScale);
        }
    }

}