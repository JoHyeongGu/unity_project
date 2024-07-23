using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Tower parent;
    void Start()
    {
        parent = GetComponentInParent<Tower>();
    }
    void Update()
    {
        float[] heart = parent.GetHeart();
        transform.localScale = new Vector3(heart[0] / heart[1], 1f, 1f);
    }
}
