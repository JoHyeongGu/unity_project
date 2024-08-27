using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : Animal
{
    private MethodTool tool = new MethodTool();
    private Coroutine moveAroundBuilding;
    private GameObject building;
    private Mouse mouse;

    void Start()
    {
        base.Init();
        SetAnimation();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!autoMove) ControledMove();
        else
        {
            if (mouse != null) agent.SetDestination(mouse.transform.position);
        }
    }

    private void ControledMove()
    {
        Vector3 moveTo = new(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += moveTo * speed * Time.deltaTime;
        if (moveTo != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveTo), speed * Time.deltaTime * 10);
    }

    private void SetAnimation()
    {
        StartCoroutine(MoveAnimation());
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

    IEnumerator Attack()
    {
        float targetDis = 2f;
        while (true)
        {
            if (mouse == null)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }
            if (Vector3.Distance(transform.position, mouse.transform.position) < targetDis)
            {
                ani.SetTrigger("attack");
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void FindMouse(Mouse find)
    {
        mouse = find;
        if (moveAroundBuilding != null) StopCoroutine(moveAroundBuilding);
        StartCoroutine(Attack());
    }

    public void MoveAroundBuilding(GameObject find = null)
    {
        if (find != null) building = find;
        GameObject[] corners = tool.FindChildObjectsWithTag(building, "BuildingCorner");
        moveAroundBuilding = StartCoroutine(WalkOnTheCorners(SortCorners(corners)));
    }

    IEnumerator WalkOnTheCorners(Transform[] corners)
    {
        while (true)
        {
            foreach (Transform corner in corners)
            {
                agent.SetDestination(corner.position);
                while (agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            }
        }
    }

    private Transform[] SortCorners(GameObject[] corners)
    {
        List<Transform> sorted = new List<Transform>();
        GameObject close = null;
        float GetDistance(GameObject point)
        {
            return Vector3.Distance(transform.position, point.transform.position);
        }
        foreach (GameObject corner in corners)
        {
            if (close == null) close = corner;
            else if (GetDistance(corner) < GetDistance(close))
                close = corner;
        }
        while (sorted.Count < 4)
        {
            foreach (GameObject corner in corners)
            {
                if (sorted.Count >= 4) break;
                if (sorted.Count == 0 && corner.name != close.name) continue;
                sorted.Add(corner.transform);
            }
        }
        return sorted.ToArray();
    }
}
