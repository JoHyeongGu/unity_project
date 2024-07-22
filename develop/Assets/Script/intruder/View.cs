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
        if (name == "View1")
        {
            ViewLowLevel(collider);
        }
        if (name == "View3")
        {
            parent.SetMoveTo(new Vector3(0f, 0f, 0f));
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (name == "View3")
        {
            ViewHighLevel(collider);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        parent.SetPurpose(null);
    }
    private void ViewLowLevel(Collider2D collider)
    {
        SetPurpose(collider, tag: "Tower");
    }
    private void ViewMediumLevel(Collider2D collider)
    {
    }
    private void ViewHighLevel(Collider2D collider)
    {
        if (parent.GetPurpose() == null)
        {
            SetPurpose(collider, tag: "Border");
        }
    }
    private void SetPurpose(Collider2D collider, string tag)
    {
        if (collider.gameObject.CompareTag(tag))
        {
            Debug.Log($"{tag} Crash!!");
            parent.SetPurpose(collider.gameObject);
        }
    }
}
