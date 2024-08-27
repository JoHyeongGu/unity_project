using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float mouseSensitivity = 400f;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minFov = 15f;
    [SerializeField] private float maxFov = 70f;

    void Update()
    {
        Move();
        Rotate();
        ZoomCamera();
    }

    private void Move()
    {
        if (Input.GetMouseButton(2))
        {
            float MouseX = 0f;
            float MouseY = 0f;
            MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
            MouseY += Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
            transform.position -= new Vector3(MouseX, 0f, MouseY);
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            float MouseX = 0f;
            float MouseY = 0f;
            MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
            MouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
            MouseY = Mathf.Clamp(MouseY, -90f, 90f);
            transform.localRotation = Quaternion.Euler(MouseY, MouseX, 0f);// 각 축을 한꺼번에 계산
        }
    }

    void ZoomCamera()
    {
        float fov = Camera.main.fieldOfView;
        float zoomState = Input.GetAxis("Mouse ScrollWheel");
        fov -= zoomState * zoomSpeed;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
