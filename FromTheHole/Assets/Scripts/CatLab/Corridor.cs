using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    private MainState mainState;
    [SerializeField] private string toRoom;
    [SerializeField] private GameObject toSwitch;

    void Start()
    {
        mainState = FindObjectOfType<MainState>();
    }

    void OnTriggerEnter()
    {
        mainState.CameraSwitch(toRoom);
        toSwitch.SetActive(true);
    }

    void OnTriggerExit()
    {
        gameObject.SetActive(false);
    }
}
