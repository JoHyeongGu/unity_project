using UnityEngine;

public class CctvMove : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minFov = 15f;
    [SerializeField] private float maxFov = 70f;

    void Start()
    {
        Debug.Log("1. 방향키 또는 WASD로 캐릭터 이동 가능 \n2. Z, X 혹은 마우스 휠로 카메라 줌 가능");
    }
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
        ZoomCamera();
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
