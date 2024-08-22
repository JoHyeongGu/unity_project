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
            cat.MoveAroundBuilding(col.gameObject);
        };
    }
}
