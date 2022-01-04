using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayInteraction : MonoBehaviour
{
    RaycastHit hit;

    public GameObject interaction;

    public Text content;

    //events
    public DialogueObject event2;

    public DialogueObject event7;

    //if it is the first time seeing a tree
    private bool firstTimeTree = true;
    //if it is the first time seeing an enemy
    private bool firstTimeEnemy = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // get player object's uiOn
        GameObject PlayerController = GameObject.Find("Player");
        Movement playerScript = PlayerController.GetComponent<Movement>();
        //get end game flag for escape
        GameObject gameManager = GameObject.Find("GameManager");
        MissionBoard missionScript = gameManager.GetComponent<MissionBoard>();
        //get dialogue for seeing trees
        DialogueSystem dialogueScript = gameManager.GetComponent<DialogueSystem>();

        if (playerScript.uiOn == false)
        {
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                if (hit.collider.name.Contains("berries"))
                {
                    content.text = "Berry, press E to interact";
                    interaction.SetActive(true);
                }
                else if (hit.collider.name.Contains("wood"))
                {
                    content.text = "wood, press E to interact";
                    interaction.SetActive(true);
                }
                else if (hit.collider.name.Contains("stone"))
                {
                    content.text = "stone, press E to interact";
                    interaction.SetActive(true);
                }
                else if (hit.collider.name.Contains("scrap"))
                {
                    content.text = "scrap, press E to interact";
                    interaction.SetActive(true);
                }
                else if (missionScript.escape && hit.collider.name.Contains("Ship"))
                {
                    content.text = "ship, press E to escape";
                    interaction.SetActive(true);
                }
                else if (hit.collider.name.Contains("BanyanTree"))
                {
                    content.text = "Tree, requires axe";
                    interaction.SetActive(true);
                    if (firstTimeTree)
                    {
                        Debug.Log("into firsttimetree");
                        firstTimeTree = false;
                        dialogueScript.startDialogue(event2);
                    }
                }
                else if (hit.collider.name.Contains("Enemy") && firstTimeEnemy) {
                    dialogueScript.startDialogue(event7);
                    firstTimeEnemy = false;
                }
                else
                {
                    interaction.SetActive(false);
                }
            }
        }

    }
}
