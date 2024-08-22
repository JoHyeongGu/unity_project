using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseView : MonoBehaviour
{
    private MethodTool tool = new MethodTool();
    private Mouse mouse;

    void Start()
    {
        mouse = GetComponentInParent<Mouse>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!mouse.autoMove) return;
        if (col.tag == "Cat")
        {
            mouse.FindCat(col.gameObject);
        }
        else if (col.tag == "Building")
        {
            GameObject target = tool.FindChildObjectWithTag(col.gameObject, "BuildingCore");
            mouse.FindBuilding(target);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (!mouse.autoMove) return;
        if (col.tag == "Cat")
        {
            mouse.FindCat(null);
        }
    }
}
