using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mouse : MonoBehaviour
{
    public bool autoMove = true;
    [SerializeField] private float speed;
    private GameObject cat;
    private GameObject building;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (cat != null)
        {
            Vector3 dirToMe = cat.transform.position - transform.position;
            agent.SetDestination(transform.position - dirToMe);
        }
        else
        {
            if (building != null)
                agent.SetDestination(building.transform.position);
            else
                agent.SetDestination(transform.position);
        }
    }

    public void FindCat(GameObject find)
    {
        cat = find;
    }

    public void FindBuilding(GameObject find)
    {
        building = find;
    }
}
