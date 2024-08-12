using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Researcher : MonoBehaviour
{
    private MainState mainState;
    [SerializeField] private float speed;
    RaycastHit rayHit = new RaycastHit();
    private bool canMove = true;
    private NavMeshAgent agent;
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        mainState = FindObjectOfType<MainState>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        MouseControl();
        StartGame();
    }

    private bool IsMoved()
    {
        return Input.GetMouseButton(0) || ((int)agent.destination.x != (int)transform.position.x
        && (int)agent.destination.z != (int)transform.position.z);
    }

    private void MouseControl()
    {
        ani.SetBool("walk", IsMoved());
        if (canMove && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out rayHit))
                agent.destination = rayHit.point;
        }
    }

    private void StartGame()
    {
        if ((mainState.enteredPortal == "" || mainState.enteredPortal == null)
            && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(poseInteract("interact"));
        }
        else if (mainState.enteredPortal == "Start" && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(poseInteract("work", delay: 10f));
            mainState.enterPortal();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Portal") mainState.enteredPortal = collider.name;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Portal") mainState.enteredPortal = null;
    }

    IEnumerator poseInteract(string name, float delay = 2f)
    {
        ani.SetTrigger(name);
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
