using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float damage = 1f;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tower"))
        {
            Destroy(this.gameObject);
        }
    }
    public float GetDamage()
    {
        return damage;
    }
}
