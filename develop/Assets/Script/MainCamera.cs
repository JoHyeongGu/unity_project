using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Camera camera;
    void Start()
    {
        camera = gameObject.GetComponent<Camera>();

    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position += new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0f);
        }
        // 마우스 휠로 줌 조절
        if (
            Input.GetAxis("Mouse ScrollWheel") != 0 &&
            !(camera.orthographicSize < 3 && Input.GetAxis("Mouse ScrollWheel") > 0) &&
            !(camera.orthographicSize > 25 && Input.GetAxis("Mouse ScrollWheel") < 0)
        )
        {
            camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 9;
        }
    }
}
