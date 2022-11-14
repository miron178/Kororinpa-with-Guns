using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int m_score;

    public int score { get => m_score; set => m_score = value; }

    private void Start()
    {
        score = 0;
    }

    public void TargetHit(Target target)
    {
        m_score++;
    }

    void OnGUI()
    {
        GUILayout.Label("Score: " + score);
    }
}
