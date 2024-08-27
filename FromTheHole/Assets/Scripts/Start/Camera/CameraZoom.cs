using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoomSpeed;

    void Start()
    {
        zoomSpeed = GetComponentInParent<CameraMove>().zoomSpeed;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);
    }
}
