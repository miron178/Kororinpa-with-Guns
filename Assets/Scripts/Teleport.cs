using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform m_destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = m_destination.position;
    }
}
