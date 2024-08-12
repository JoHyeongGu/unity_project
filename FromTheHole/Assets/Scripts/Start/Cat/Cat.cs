using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    [SerializeField] private bool autoMove = true;
    [SerializeField] private float speed = 5f;
    private Vector3 moveTo = new();
    private NavMeshAgent agent;
    private Animator ani;
    private Vector3[] buildingPoints;

    void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!autoMove) ControledMove();
        else AutoMove();
    }

    private void ControledMove()
    {
        moveTo.x = Input.GetAxis("Horizontal");
        moveTo.z = Input.GetAxis("Vertical");
        ani.SetBool("walk", moveTo != Vector3.zero);
        transform.position += moveTo * speed * Time.deltaTime;
        if (moveTo != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveTo), speed * Time.deltaTime * 10);
    }

    private void AutoMove()
    {
        ani.SetBool("walk", agent.destination != transform.position);
    }

    public void FindMouse(GameObject mouse)
    {
        StopAllCoroutines();
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
                yield return new WaitForSeconds(Random.Range(0.2f, 2f));
            }
        }
    }
}
