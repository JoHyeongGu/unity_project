using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatView : MonoBehaviour
{
    private Cat cat;
    private Mouse mouse;

    void Start()
    {
        cat = GetComponentInParent<Cat>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!cat.autoMove) return;
        if (col.tag == "Mouse")
        {
            Debug.Log("쥐 발견!!");
            mouse = col.gameObject.GetComponent<Mouse>();
            cat.FindMouse(mouse);
        }
        else if (mouse == null && col.tag == "Building")
        {
            cat.MoveAroundBuilding(col.gameObject);
        };
    }
}
