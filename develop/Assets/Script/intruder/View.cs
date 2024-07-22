using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private AutoMove parent;
    void Start()
    {
        parent = GetComponentInParent<AutoMove>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Tower")
        {
            parent.SetPurpose(collider.gameObject);
        }
    }
}
