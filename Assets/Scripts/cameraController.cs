using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class cameraController : MonoBehaviour
{
    public float sensitivity = 30f;
    //Vector2 DeltaPointer;

    public Vector2 rotation;

    
    // Update is called once per frame
    void Update()
    {
        //get player controller for the uion flag
        GameObject PlayerController = GameObject.Find("player");
        playerController playerScript = PlayerController.GetComponent<playerController>();

        if (playerScript.uiOn == false) {
            //rotation.x += Mouse.current.delta.x.ReadValue();
            rotation.y += Mouse.current.delta.y.ReadValue();

            transform.localRotation = Quaternion.Euler(-rotation.y, 0, 0);
        }
        
       
    }
}
