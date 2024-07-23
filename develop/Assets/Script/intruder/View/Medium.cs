using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : MonoBehaviour
{
    private AutoMove parent;
    void Start()
    {
        parent = GetComponentInParent<AutoMove>();
        float dis = parent.GetAttackDis();
        transform.localScale = new Vector3(dis, dis, dis);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tower"))
        {
            parent.AutoAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tower"))
        {
            parent.StopAutoAttack();
        }
    }
}
