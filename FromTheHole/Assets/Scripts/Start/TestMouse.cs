using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouse : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Cat") Destroy(this.gameObject);
    }
}
