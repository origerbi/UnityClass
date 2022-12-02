using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    Animator anim;
    public GameObject key;
    private bool keySpawned = false;
    private bool keyPickedUp = false;
    private Vector3 keyRotation = new Vector3(0, -90f, 90f);
    private float keyScale = 0.7f;

    void Start()
    {
        anim = this.gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (anim.GetBool("openChest") && !keySpawned)
        {
            keySpawned = true;
            Instantiate(key, this.gameObject.transform.position, Quaternion.Euler(keyRotation));
            key.transform.localScale = new Vector3(keyScale, keyScale, keyScale);
            Animator keyAnimator = key.AddComponent<Animator>();
            keyAnimator.runtimeAnimatorController = Resources.Load("KeyAnimator") as RuntimeAnimatorController;
        }
    }
}
