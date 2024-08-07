using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    private MainState mainState;
    [SerializeField] private string toRoom;

    void Start()
    {
        mainState = FindObjectOfType<MainState>();
    }

    void OnTriggerEnter()
    {
        mainState.cameraSwitch(toRoom);
    }
}
