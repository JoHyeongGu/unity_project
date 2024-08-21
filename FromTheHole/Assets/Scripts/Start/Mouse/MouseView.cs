using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseView : MonoBehaviour
{

    private Mouse mouse;

    void Start()
    {
        mouse = GetComponentInParent<Mouse>();
    }

    void OnTriggerEnter(Collider col)
    {
    }

}
