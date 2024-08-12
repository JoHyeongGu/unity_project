using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public bool autoMove = true;
    [SerializeField] private float speed = 5f;
    private Vector3[] buildingPoints;
    private Coroutine movePointRoutine;
    private NavMeshAgent agent;
    private GameObject targetMouse;
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetAnimation();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!autoMove) ControledMove();
    }

    private void ControledMove()
    {
        Vector3 moveTo = new();
        moveTo.x = Input.GetAxis("Horizontal");
        moveTo.z = Input.GetAxis("Vertical");
        transform.position += moveTo * speed * Time.deltaTime;
        if (moveTo != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveTo), speed * Time.deltaTime * 10);
    }

    private void SetAnimation()
    {
        StartCoroutine(MoveAnimation());
        StartCoroutine(AttackAnimation());
    }

    IEnumerator MoveAnimation()
    {
        float moveDis = 0.1f;
        while (true)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForSeconds(0.1f);
            ani.SetBool("walk", Vector3.Distance(prevPos, transform.position) > moveDis);
        }
    }

    IEnumerator AttackAnimation()
    {
        float targetDis = 2f;
        while (true)
        {
            if (targetMouse == null)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }
            if (Vector3.Distance(transform.position, targetMouse.transform.position) < targetDis)
            {
                ani.SetTrigger("attack");
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void FindMouse(GameObject mouse)
    {
        targetMouse = mouse;
        StopCoroutine(movePointRoutine);
        StartCoroutine(MoveToMouseRoutine(mouse));
    }

    IEnumerator MoveToMouseRoutine(GameObject mouse)
    {
        while (mouse != null)
        {
            agent.SetDestination(mouse.transform.position);
            yield return new WaitForSeconds(1f);
        }
        SetDesWithPointArray(buildingPoints);
    }

    public void SetDesWithPointArray(Vector3[] pointArray)
    {
        buildingPoints = pointArray;
        movePointRoutine = StartCoroutine(MovePointRoutine(pointArray));
    }

    IEnumerator MovePointRoutine(Vector3[] pointArray)
    {
        while (true)
        {
            foreach (Vector3 point in pointArray)
            {
                agent.SetDestination(point);
                while (agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            }
        }
    }
}
