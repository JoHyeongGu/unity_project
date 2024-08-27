using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 300f;
    public float rotateSpeed = 100f;
    public float zoomSpeed = 10f;

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (Input.GetMouseButton(2))
        {
            float MouseX = 0f;
            float MouseY = 0f;
            MouseX += Input.GetAxisRaw("Mouse X") * moveSpeed * Time.deltaTime;
            MouseY += Input.GetAxisRaw("Mouse Y") * moveSpeed * Time.deltaTime;
            // transform.position -= new Vector3(MouseX, 0f, MouseY);
            transform.localPosition -= transform.TransformDirection(new Vector3(MouseX, 0f, MouseY));
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            float MouseX = 0f;
            float MouseY = 0f;
            MouseX += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
            MouseY -= Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(MouseY, MouseX, 0f);
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }
}
