using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    Animator anim;
    int dir = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponentInParent<Animator>();
        dir = (this.gameObject.name.StartsWith("Front")) ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetInteger("dir", dir);
        anim.SetBool("OpenDoor", true);
        Debug.Log("Door is opening - " + anim.GetInteger("dir") + " " + anim.GetBool("OpenDoor"));

    }

    void OnTriggerExit(Collider other)
    {
        anim.SetInteger("dir", 0);
        anim.SetBool("OpenDoor", false);
        Debug.Log("Door is closing - " + anim.GetInteger("dir") + " " + anim.GetBool("OpenDoor"));
    }
}
