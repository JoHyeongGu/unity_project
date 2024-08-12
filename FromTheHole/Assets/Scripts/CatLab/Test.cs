using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    private NavMeshAgent agent;
    RaycastHit rayHit = new RaycastHit();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out rayHit))
                agent.destination = rayHit.point;
        }

    }
}
