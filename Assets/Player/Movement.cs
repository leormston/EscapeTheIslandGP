using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalInput;
    [SerializeField] float jumpHeight = 3.5f;
    bool jump;
    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask ;
    bool isGrounded;
    public LayerMask Ground;

    //if ui is on no movement allowed
    public bool uiOn = false;
    public void Update ()
    {
        //physics.checksphere creates a sphere and sees if it intersects with anything
        // isGrounded = Physics.Raycast(transform.position, -transform.up, 2f, Ground);
        //     walkPointSet = true;
        // isGrounded = Physics.CheckSphere(transform.position, 2f);
        // if(isGrounded)
        // {
        //     verticalVelocity.y = 0;
        // }

        //Jump v  = sqrt(-2 * jumpheight * gravity)
        
        //if ui is on nothing can move
        if (uiOn == false) {
            if (jump)
            {
                // if(isGrounded)
                // {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
                // }

                jump = false;
            }
            Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
            controller.Move(horizontalVelocity * Time.deltaTime);

            verticalVelocity.y += gravity * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }

        //if i is pressed then open inventory, lock all movement
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            Debug.Log(uiOn);
            uiOn = true;
            //reference the inventory ui
            GameObject resource = GameObject.Find("GameManager");
            ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();

            resourceScript.openInventory();
        }
        else if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            uiOn = true;
            //reference the crafting menu
            GameObject craft = GameObject.Find("GameManager");
            Crafting craftingScript = craft.GetComponent<Crafting>();

            craftingScript.openCrafting();
        }

    }
   public void RecieveInput(Vector2 _horizontalInput)
   {
       horizontalInput = _horizontalInput;
   }

   public void OnJumpPressed ()
   {
       jump = true;
   }
}
