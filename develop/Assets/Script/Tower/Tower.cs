using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float maxHeart = 10;
    [SerializeField]
    private float heart = 10;


    public float[] GetHeart()
    {
        return new float[2] { heart, maxHeart };

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("IntruderAttack"))
        {
            Attack weapon = collider.gameObject.GetComponentInParent<Attack>();
            heart -= weapon.GetDamage();
        }
    }
    void Update()
    {
        if (heart <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
