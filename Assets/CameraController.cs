using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform Target;
    public float SmoothSpeed = 0.4f;

    public Vector3 Offset = new Vector3(0f, 0f, -10);

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

        var currentPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, 0f) + Offset;
        transform.position = currentPosition;
    }
}
