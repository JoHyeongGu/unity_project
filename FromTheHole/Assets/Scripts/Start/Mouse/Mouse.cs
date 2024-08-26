using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mouse : MonoBehaviour
{
    public bool autoMove = true;
    public float speed;
    [SerializeField] private float hp = 100f;
    // [SerializeField] private float atk = 1f;
    private GameObject cat;
    private GameObject building;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (hp <= 0) Destroy(this.gameObject);
        if (cat != null)
        {
            Vector3 dirToMe = cat.transform.position - transform.position;
            try { agent.SetDestination(transform.position - dirToMe); } finally { }
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

    public void Attacked(Collider atkObj)
    {
        Cat _cat = atkObj.gameObject.GetComponentInParent<Cat>();
        hp -= _cat.GetAtk();
        transform.position += new Vector3(0f, 1f, 0f);
        Debug.Log($"Mouse HP: {hp} / 100");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Attack") Attacked(col);
    }
}
