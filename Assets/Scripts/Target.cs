using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TargetHitEvent : UnityEvent<Target> { }

public class Target : MonoBehaviour
{
    private TargetHitEvent m_hit = new TargetHitEvent();

    public void AddListener(UnityAction<Target> call)
    {
        m_hit.AddListener(call);
    }
    public void RemoveListener(UnityAction<Target> call)
    {
        m_hit.RemoveListener(call);
    }

    private void Start()
    {
        Points points = GameObject.Find("ScoreKeeper").GetComponent<Points>();
        AddListener(points.TargetHit);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            m_hit.Invoke(this);
            GameObject.Destroy(gameObject);
        }
    }
}
