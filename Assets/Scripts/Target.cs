using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Points m_points = null;

    private void Start()
    {
        m_points = GameObject.Find("ScoreKeeper").GetComponent<Points>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            m_points.score++;
            GameObject.Destroy(gameObject);
        }
    }
}
