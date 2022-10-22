using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // the target to follow
    public Transform target;

    // speed between 0 - no camera movement and 1 - follow immediately
    public float smoothSpeed = 10f;

    // desired offset between camera and target
    public Vector3 offset;

    void LateUpdate()
    {
        // get the new position of the player
        Vector3 desiredPostion = target.position + offset;

        // move towards the desired position using linear interpolation (lerp)
        transform.position = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed * Time.deltaTime);
    }
}
