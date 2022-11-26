using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMotion : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("canOpenChest"))
        {
            anim.SetBool("openChest", true);
            Debug.Log("space key was pressed");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("canOpenChest", true);
        Debug.Log("can Open Chest");
    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool("canOpenChest", false);
        Debug.Log("can't Open Chest");

    }
}
