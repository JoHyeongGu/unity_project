using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    [SerializeField]
    private Animator ani;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ani.SetBool("up", true);
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            ani.SetBool("up", false);
        }
    }
}
