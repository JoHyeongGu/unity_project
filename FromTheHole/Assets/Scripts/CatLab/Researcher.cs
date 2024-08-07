using UnityEngine;
using System.Collections;

public class Researcher : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 moveTo = new Vector3();
    private Animator animator;
    public MainState mainState;
    private bool canMove = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        mainState = FindObjectOfType<MainState>();
    }
    void Update()
    {
        MoveControl();
        StartGame();
    }
    private void MoveControl()
    {
        moveTo = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (canMove && moveTo != Vector3.zero)
        {
            animator.SetBool("walk", true);
            transform.position += moveTo * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveTo), Time.deltaTime * speed * 10);
        }
        else animator.SetBool("walk", false);

        // 포즈 잡기
        if ((mainState.enteredPortal == "" || mainState.enteredPortal == null)
            && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(poseInteract("interact"));
        }

        // 맵 밖으로 나가면 리스폰
        if (transform.position.y < -5f) transform.position = Vector3.zero;
    }

    private void StartGame()
    {
        if (mainState.enteredPortal == "Start" && Input.GetKeyDown(KeyCode.Space))
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
        animator.SetTrigger(name);
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
