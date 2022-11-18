using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("OpenDoor", true);
    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool("OpenDoor", false);
    }
}
