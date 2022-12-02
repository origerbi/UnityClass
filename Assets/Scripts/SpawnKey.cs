using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    Animator anim;
    public GameObject key;
    public RuntimeAnimatorController keyAnimatorController;
    private bool keySpawned = false;
    private bool keyPickedUp = false;
    private Vector3 keyRotation;
    private float keyScale = 0.7f;

    void Start()
    {
        anim = this.gameObject.GetComponentInParent<Animator>();
        keyRotation = this.gameObject.transform.rotation.eulerAngles - new Vector3(0, 90f, 90f);
    }

    void Update()
    {
        if (anim.GetBool("openChest") && !keySpawned)
        {
            keySpawned = true;
            GameObject k = Instantiate(key, this.gameObject.transform.position, Quaternion.Euler(keyRotation));
            k.transform.localScale = new Vector3(keyScale, keyScale, keyScale);
            Animator keyAnimator = k.AddComponent<Animator>();
            keyAnimator.runtimeAnimatorController = keyAnimatorController;
        }
    }
}
