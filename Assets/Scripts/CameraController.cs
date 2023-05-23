using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.fixedDeltaTime);
    }
}
    