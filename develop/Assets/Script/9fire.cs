using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private bool autoMode = true;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private Animator ani;
    private Vector3 moveTo = new(0f, 0f, 0f);

    void Start()
    {
        if (autoMode)
        {
            AutoMove();
        }
    }

    void Update()
    {
        if (!autoMode)
        {
            Controlled();
        }
        Rotate();
        transform.position += moveTo * speed * Time.deltaTime;
    }

    private void AutoMove()
    {
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (autoMode)
        {
            float horizonInput = Random.Range(-1, 2);
            float verticalInput = Random.Range(-1, 2);
            moveTo = new(horizonInput, verticalInput, 0f);
            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }
    }

    private void Controlled()
    {
        StopCoroutine("ChangeMove");
        float horizonInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveTo = new(horizonInput, verticalInput, 0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("attack");
        }
    }

    private void Rotate()
    {
        ani.SetInteger("vertical", (int)moveTo.y);
        ani.SetInteger("horizonal", (int)moveTo.x);
    }

}
