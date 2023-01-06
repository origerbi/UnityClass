using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBehaviour : MonoBehaviour
{

    private enum ChestState { Unreachable, Closed, Opened, KeyTaken };
    private ChestState chestState = ChestState.Unreachable;

    public GameObject keyInChest;
    private Animator chestAnim;
    private Animator keyAnim;

    public Camera playerEye;

    // Start is called before the first frame update
    void Start()
    {
        chestAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        keyAnim = keyInChest.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chestState == ChestState.Closed)
            tryToOpenChest();
        else if (chestState == ChestState.Opened)
            tryToPickKey();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            if (chestState == ChestState.Unreachable)
            {
                TextPrompt.instance.showPrompt("Press Space to open chest");
                chestState = ChestState.Closed;
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            TextPrompt.instance.hidePrompt();

            if (chestState == ChestState.Closed)
                chestState = ChestState.Unreachable;
        }
    }

    void tryToOpenChest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chestState = ChestState.Opened;
            chestAnim.SetTrigger("openChest");
            keyAnim.SetTrigger("animate");
            TextPrompt.instance.hidePrompt();
            chestState = ChestState.Opened;
        }
    }



    void tryToPickKey()
    {
        if (!Physics.CheckSphere(playerEye.transform.position, 2, LayerMask.GetMask("Collectables")))
        {
            TextPrompt.instance.hidePrompt();
            return;
        }

        TextPrompt.instance.showPrompt("Press Space to pick up key");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyInChest.SetActive(false);
            chestState = ChestState.KeyTaken;
            GameManager.instance.KeyPickedUp();
            TextPrompt.instance.hidePrompt();
        }

    }
}
