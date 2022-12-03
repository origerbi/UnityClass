using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    Animator keyAnim;
    Animator ChestAnim;
    bool pickedUp;
    void Start()
    {
        keyAnim = this.gameObject.GetComponent<Animator>();
        ChestAnim = this.gameObject.transform.parent.transform.Find("Openable_Chest").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChestAnim.GetBool("openChest"))
        {
            keyAnim.SetBool("animate", true);
        }
    }

    public void PickUp() {
        pickedUp = true;
        gameObject.SetActive(false);
    }

    public bool IsPickedUp() {
        return pickedUp;
    }
}
