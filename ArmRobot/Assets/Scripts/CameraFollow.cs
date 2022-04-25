using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float cameraHeight = 5.0f;

    void Update()
    {
        Vector3 pos = target.transform.position;
        pos.y = cameraHeight;
        transform.position = pos;
    }
}
