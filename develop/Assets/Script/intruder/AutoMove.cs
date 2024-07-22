using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private Animator ani;
    private Vector3 moveTo = new(0f, 0f, 0f);
    private GameObject purpose = null;

    void Start()
    {
        StartCoroutine(RandomMove());
    }

    void Update()
    {
        Rotate();
        transform.position += moveTo * speed * Time.deltaTime;
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            if (purpose == null)
            {
                float horizonInput = Random.Range(-1, 2);
                float verticalInput = Random.Range(-1, 2);
                moveTo = new(horizonInput, verticalInput, 0f);
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                Debug.Log($"Move to {purpose.transform.position}");
                MoveToPurpose();
            }
        }
    }

    public void SetPurpose(GameObject newPurpose)
    {
        Debug.Log($"purpose change to {newPurpose}");
        purpose = newPurpose;
    }

    void MoveToPurpose()
    {
        Vector3 purposePos = purpose.transform.position;
        Vector3 myPos = transform.position;
        float differX = myPos.x - purposePos.x;
        float differY = myPos.y - purposePos.y;
        if (differX < -1)
        {
            moveTo.x = 1;
        }
        else if (differX > 1)
        {
            moveTo.x = -1;
        }
        else
        {
            moveTo.x = 0;
        }
        if (differY < -1)
        {
            moveTo.y = 1;
        }
        else if (differY > 1)
        {
            moveTo.y = -1;
        }
        else
        {
            moveTo.y = 0;
        }
        Debug.Log(moveTo);
    }

    // private void Controlled()
    // {
    //     StopCoroutine("ChangeMove");
    //     float horizonInput = Input.GetAxisRaw("Horizontal");
    //     float verticalInput = Input.GetAxisRaw("Vertical");
    //     moveTo = new(horizonInput, verticalInput, 0f);
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         ani.SetTrigger("attack");
    //     }
    // }

    private void Rotate()
    {
        ani.SetInteger("vertical", (int)moveTo.y);
        ani.SetInteger("horizonal", (int)moveTo.x);
    }

}
