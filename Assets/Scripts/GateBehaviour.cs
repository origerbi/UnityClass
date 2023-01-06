using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GateBehaviour : MonoBehaviour
{
    private enum GateState { Unreachable, Locked, Unlocked };
    private GateState gateState = GateState.Unreachable;

    private NavMeshObstacle navMeshObstacle = null;

    private void Awake()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
    }

    void Update()
    {
        if (gateState == GateState.Locked)
            tryToUnlockGate();
    }

    private void tryToUnlockGate()
    {
        if (!GameManager.instance.KeyWithPlayer())
        {
            TextPrompt.instance.showPrompt("You need a key to unlock this gate");
            return;
        }

        TextPrompt.instance.showPrompt("Press Space to use the key");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("OpenGate");
            navMeshObstacle.enabled = false;

            GameManager.instance.KeyUsed();
            gateState = GateState.Unlocked;
            TextPrompt.instance.hidePrompt();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            if (gateState == GateState.Unreachable)
                gateState = GateState.Locked;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            if (gateState == GateState.Locked)
            {
                gateState = GateState.Unreachable;
                TextPrompt.instance.hidePrompt();
            }
        }
    }
}
