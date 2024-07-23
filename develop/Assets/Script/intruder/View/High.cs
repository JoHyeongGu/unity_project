using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High : MonoBehaviour
{
    private AutoMove parent;
    void Start()
    {
        parent = GetComponentInParent<AutoMove>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        parent.SetMoveTo(new Vector3(0f, 0f, 0f));
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (parent.GetPurpose() == null)
        {
            if (collider.gameObject.CompareTag("Border"))
            {
                parent.SetPurpose(collider.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        parent.SetPurpose(null);
    }
}
