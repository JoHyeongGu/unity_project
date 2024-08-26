using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public bool autoMove = true;
    public float speed = 5f;
    [SerializeField] protected float hp = 100f;
    [SerializeField] protected float atk = 1f;
    protected NavMeshAgent agent;
    protected Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public float GetAtk()
    {
        return atk;
    }

    public void Attacked(Collider atkObj)
    {
        Animal enimy = atkObj.gameObject.GetComponentInParent<Animal>();
        hp -= enimy.GetAtk();
        transform.position += new Vector3(0f, 1f, 0f);
        Debug.Log($"Mouse HP: {hp} / 100");
    }
}
