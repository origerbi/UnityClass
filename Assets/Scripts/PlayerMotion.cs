using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    CharacterController controller;
    float speed = 3;
    float angularSpeed = 100;
    public Camera aCamera; // must be connected to real camera in Unity
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;
        float rotationAboutY;
        float rotationAboutX;

        // rotate a camera about X-Axis
        rotationAboutX = -1*angularSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        aCamera.transform.Rotate(rotationAboutX, 0, 0);

        // rotate player about Y-Axis
        rotationAboutY = angularSpeed* Time.deltaTime * Input.GetAxis("Mouse X");
        transform.Rotate(0, rotationAboutY, 0);



        dz = speed*Time.deltaTime*Input.GetAxis("Vertical"); // can be -1, 0 or 1
        dx = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        // simple motion forward
        //        this.transform.Translate(new Vector3(0,0,0.06f));
        Vector3 motion = new Vector3(dx, -0.2f, dz);
        motion = transform.TransformDirection(motion); // transform to local coordinates
        
        controller.Move(motion); // in global coordinates
    }
}
