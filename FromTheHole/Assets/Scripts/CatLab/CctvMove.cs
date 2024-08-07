using UnityEngine;

public class CctvMove : MonoBehaviour
{
    public bool activate = true;
    public Transform target;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minFov = 15f;
    [SerializeField] private float maxFov = 70f;

    void Update()
    {
        if (activate)
        {
            LookTarget();
            ZoomCamera();
        }
    }

    void LookTarget()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    void ZoomCamera()
    {
        float fov = Camera.main.fieldOfView;
        float zoomState = Input.GetAxis("Mouse ScrollWheel");
        bool zKey = Input.GetKey(KeyCode.Z);
        bool xKey = Input.GetKey(KeyCode.X);
        if (zKey || xKey)
        {
            zoomState = zKey ? 0.01f : xKey ? -0.01f : zoomState;
        }
        fov -= zoomState * zoomSpeed;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
