using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodTool
{
    public GameObject FindChildObjectWithTag(GameObject parent, string tag)
    {
        foreach (Transform pos in parent.GetComponentsInChildren<Transform>())
        {
            if (pos.CompareTag(tag))
            {
                return pos.gameObject;
            }
        }
        return null;
    }

    public GameObject[] FindChildObjectsWithTag(GameObject parent, string tag)
    {
        List<GameObject> result = new List<GameObject>();
        foreach (Transform pos in parent.GetComponentsInChildren<Transform>())
        {
            if (pos.CompareTag(tag))
            {
                result.Add(pos.gameObject);
            }
        }
        return result.ToArray();
    }
}
