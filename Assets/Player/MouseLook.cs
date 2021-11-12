using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 150f;
    [SerializeField] float sensitivityY = 0.38f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 65f;
    float xRotation = 0f;

    private void Start()
    {
        
    }
    public void RecieveInput (Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;

    }

    private void Update()
    {
        GameObject PlayerController = GameObject.Find("Player");
        Movement playerScript = PlayerController.GetComponent<Movement>();
        if (playerScript.uiOn == false)
        {
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -25, 65);
            Vector3 targetRotation = transform.eulerAngles;

            targetRotation.x = xRotation;
            playerCamera.eulerAngles = targetRotation;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

}
