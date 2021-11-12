using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    [SerializeField] float health;
    Vector2 horizontalInput;
    Vector2 mouseInput;
    public GameObject projectile;
    public Text healthText;
    
    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        movement.RecieveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
        GameObject gameManager = GameObject.Find("GameManager");
        EquipItem equipScript = gameManager.GetComponent<EquipItem>();
        //get uiOn
        GameObject player = GameObject.Find("Player");
        Movement playerScript = player.GetComponent<Movement>();
        //get equipItem to see if slinger is on
        
        if (equipScript.slingerOn   == true) {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
                rb.AddForce(transform.up * 2f, ForceMode.Impulse);
            }
         }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        healthText.text = "Health: "+ health.ToString();

        //if (health <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
        if (health <= 0) {
            GameObject gameManager = GameObject.Find("GameManager");
            GameOver gameOverScript = gameManager.GetComponent<GameOver>();
            gameOverScript.displayGameOver(1);
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider col)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if(col.gameObject.name == "EnemyCube(Clone)")
        {
            TakeDamage(5);
            Destroy(col.gameObject);
        }
        
        
     
    }
    private void OnEnable ()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();

    }

}
