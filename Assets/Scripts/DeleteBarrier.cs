using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DeleteBarrier : MonoBehaviour
{
    [SerializeField]
    Target[] targets;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].AddListener(TargetHit);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    public void TargetHit(Target target)
    {
        int count = 0;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] == target)
            {
                targets[i].RemoveListener(TargetHit);
                targets[i] = null;
            }
            else if (targets[i] != null)
            {
                count++;
            }
        }
        if (count == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

}
