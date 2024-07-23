using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Low : MonoBehaviour
{
    private AutoMove parent;
    private GameObject tower = null;
    void Start()
    {
        parent = GetComponentInParent<AutoMove>();
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (tower == null && collider.gameObject.CompareTag("Tower"))
        {
            tower = collider.gameObject;
            parent.SetPurpose(collider.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (tower != null && collider.gameObject.CompareTag("Tower"))
        {
            tower = null;
            parent.SetPurpose(null);
        }
    }
}
