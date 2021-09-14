using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 androidoffset;
    Vector3 desiredPosition;

    void FixedUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
        {
            androidoffset.y = 1f;
            androidoffset.z = -2.75f;
            desiredPosition = desiredPosition - androidoffset;
        }
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

       transform.LookAt(target);
    }

}
