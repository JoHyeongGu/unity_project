using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float attackDis = 0.5f;
    [SerializeField]
    private Animator ani;
    private Vector3 moveTo = new(0f, 0f, 0f);
    private Coroutine moveRoutine = null;
    private GameObject purpose = null;
    public GameObject weapon = null;
    private Coroutine attackRoutine = null;

    void Start()
    {
        moveRoutine = StartCoroutine(AutoMoving());
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
                MoveToPurpose(desPos: new Vector3(0f, 0f, 0f));
                yield return new WaitForSeconds(Random.Range(5f, 9f));
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
    public float GetAttackDis()
    {
        return attackDis;
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
        if (differX < -(attackDis / 6.4))
        {
            moveTo.x = reverse ? -1 : 1;
        }
        else if (differX > attackDis / 6.4)
        {
            moveTo.x = reverse ? 1 : -1;
        }
        else
        {
            moveTo.x = 0;
        }
        if (differY < -(attackDis / 6.4))
        {
            moveTo.y = reverse ? -1 : 1;
        }
        else if (differY > attackDis / 6.4)
        {
            moveTo.y = reverse ? 1 : -1;
        }
        else
        {
            moveTo.y = 0;
        }
    }

    public void AutoAttack()
    {
        attackRoutine = StartCoroutine(AutoAttackRoutine());
    }
    public void StopAutoAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
        }
    }

    IEnumerator AutoAttackRoutine()
    {
        while (true)
        {
            if (purpose == null || purpose.tag != "Tower" || weapon == null)
            {
                StopAutoAttack();
            }
            ani.SetTrigger("attack");
            yield return new WaitForSeconds(0.5f);
            Instantiate(weapon, purpose.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
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
