using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: This script will make the camera loosely follow the player through the scene

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        // Set target position
        Vector3 targetPosition = target.position + offset;

        // Use Lerp to make the camera position move to the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
