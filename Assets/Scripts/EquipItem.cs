using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{

    public GameObject axe;

    public Transform handPos;

    public GameObject player;

    public Button axeEquip;

    public bool equip;

    public bool axeOn;

    public bool slingerOn;

    public Button slingerEquip;

    public bool firstAxe = false;
    public bool firstSlinger = false;

    public DialogueObject event4;
    public DialogueObject event8;

    private void Start()
    {
        axeEquip.onClick.AddListener(equipTool);
        slingerEquip.onClick.AddListener(equipslinger);
    }

    public void equipTool() {
        //equip the axe
        GameObject stoneAxe = Instantiate(axe, handPos.position, handPos.rotation);
        stoneAxe.transform.parent = player.transform;
        //axe on
        axeOn = true;
        if (firstAxe == false) {
            GameObject gameManager = GameObject.Find("GameManager");
            displayTutorials tutorialScript = gameManager.GetComponent<displayTutorials>();
            //get dialogue for seeing trees
            DialogueSystem dialogueScript = gameManager.GetComponent<DialogueSystem>();
            //close inventory
            ResourceCounter resourceScript = gameManager.GetComponent<ResourceCounter>();
            resourceScript.closeInventory();
            dialogueScript.startDialogue(event4);
            //tutorialScript.displayAxeTutorial();
            firstAxe = true;
        }
    }
    public void equipslinger()
    {
        slingerOn = true;
        if (firstSlinger == false)
        {
            GameObject gameManager = GameObject.Find("GameManager");
            displayTutorials tutorialScript = gameManager.GetComponent<displayTutorials>();
            DialogueSystem dialogueScript = gameManager.GetComponent<DialogueSystem>();
            ResourceCounter resourceScript = gameManager.GetComponent<ResourceCounter>();
            resourceScript.closeInventory();
            dialogueScript.startDialogue(event8);
            //tutorialScript.displaySlingerTutorial();
            firstSlinger = true;
        }
    }
}
