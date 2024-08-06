using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Researcher : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 moveTo = new Vector3();
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        moveTo = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += moveTo * speed * Time.deltaTime;
        if (moveTo != Vector3.zero)
        {
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveTo), Time.deltaTime * speed * 10);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }
}
