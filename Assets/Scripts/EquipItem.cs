using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{

    public GameObject axe;

    [SerializeField] public GameObject slingShot;

    [SerializeField]  public Transform leftHandPos;

    [SerializeField]  public Transform handPos;

    [SerializeField] public Transform rightHandPos;

    public GameObject player;

    public Button axeEquip;

    public bool equip;

    public bool axeOn;

    public bool slingOn;

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
        GameObject stoneAxe = Instantiate(axe, leftHandPos.position, leftHandPos.rotation);
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
        
        GameObject sling = Instantiate(slingShot, rightHandPos.position, rightHandPos.rotation);
        sling.transform.parent = player.transform;
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
