using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(AutoMoving());
    }

    void Update()
    {
        Rotate();
        transform.position += moveTo * speed * Time.deltaTime;
    }
    private void Rotate()
    {
        ani.SetInteger("vertical", (int)moveTo.y);
        ani.SetInteger("horizonal", (int)moveTo.x);
    }

    IEnumerator AutoMoving()
    {
        while (true)
        {
            if (purpose == null)
            {
                RandomMove();
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
            else if (purpose.CompareTag("Tower"))
            {
                MoveToPurpose();
                yield return new WaitForSeconds(0.5f);
            }
            else if (purpose.CompareTag("Border"))
            {
                Debug.Log("before moving");
                MoveToPurpose(desPos: new Vector3(0f, 0f, 0f));
                Debug.Log("before cooltime");
                yield return new WaitForSeconds(Random.Range(5f, 9f));
                Debug.Log("after cooltime");
            }
        }
    }

    void RandomMove()
    {
        float horizonInput = Random.Range(-1, 2);
        float verticalInput = Random.Range(-1, 2);
        moveTo = new(horizonInput, verticalInput, 0f);
    }

    public void SetPurpose(GameObject newPurpose)
    {
        purpose = newPurpose;
    }
    public GameObject GetPurpose()
    {
        return purpose;
    }

    public void SetMoveTo(Vector3 vector)
    {
        moveTo = vector;
    }

    void MoveToPurpose(bool reverse = false, Vector3? desPos = null)
    {
        Vector3 purposePos = purpose.transform.position;
        if (desPos != null)
        {
            purposePos = (Vector3)desPos;
        }
        Vector3 myPos = transform.position;
        float differX = myPos.x - purposePos.x;
        float differY = myPos.y - purposePos.y;
        if (differX < -1)
        {
            moveTo.x = reverse ? -1 : 1;
        }
        else if (differX > 1)
        {
            moveTo.x = reverse ? 1 : -1;
        }
        else
        {
            moveTo.x = 0;
        }
        if (differY < -1)
        {
            moveTo.y = reverse ? -1 : 1;
        }
        else if (differY > 1)
        {
            moveTo.y = reverse ? 1 : -1;
        }
        else
        {
            moveTo.y = 0;
        }
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

}
