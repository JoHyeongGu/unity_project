using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Animal
{
    private GameObject cat;
    private GameObject building;

    void Start()
    {
        base.Init();
    }

    void Update()
    {
        if (hp <= 0) Destroy(this.gameObject);
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

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Attack")
        {
            Cat cat = col.gameObject.GetComponentInParent<Cat>();
            Attacked(cat);
        }
    }
}
