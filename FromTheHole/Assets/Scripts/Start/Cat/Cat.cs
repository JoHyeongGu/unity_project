using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public bool autoMove = true;
    [SerializeField] private float speed = 5f;
    private NavMeshAgent agent;
    private Animator ani;
    private Vector3[] buildingPoints;

    void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(MoveAnimation());
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


    IEnumerator MoveAnimation()
    {
        float dis = 0.2f;
        while (true)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForSeconds(0.1f);
            ani.SetBool("walk", Vector3.Distance(prevPos, transform.position) > dis);
        }
    }

    public void FindMouse(GameObject mouse)
    {
        StopCoroutine(MovePointRoutine(new Vector3[4]));
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
        StartCoroutine(MovePointRoutine(pointArray));
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
