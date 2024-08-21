using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatView : MonoBehaviour
{

    private Cat cat;
    private GameObject mouse;

    void Start()
    {
        cat = GetComponentInParent<Cat>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!cat.autoMove) return;
        if (col.tag == "Mouse")
        {
            mouse = col.gameObject;
            cat.FindMouse(mouse);
        }
        else if (col.tag == "Building" && mouse == null)
        {
            Transform target = col.gameObject.GetComponent<Transform>();
            Vector3[] pointArray = GetMovePointList(target);
            cat.SetDesWithPointArray(pointArray);
        };
    }

    private Vector3[] GetMovePointList(Transform col)
    {
        float width = col.localScale.x / 2 + 0.5f;
        float length = col.localScale.z / 2 + 0.5f;
        Vector3[] result = new Vector3[4]{
            col.position + new Vector3(width, 0f, length),
            col.position + new Vector3(width, 0f, -length),
            col.position + new Vector3(-width, 0f, -length),
            col.position + new Vector3(-width, 0f, length),
        };
        return result;
    }
}
