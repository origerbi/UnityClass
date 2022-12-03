using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaivor : MonoBehaviour
{
    public KeyBehaviour KeyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (KeyBehaviour.IsPickedUp()) {
            //anim.SetBool("OpenGate", true);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //anim.SetBool("OpenGate", false);
    }
}
