using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoard : MonoBehaviour
{
    public Text missionContent;
    public bool escape = false;
    private bool firstHull = false;
    private bool firstEngine = false;
    public DialogueObject event5;
    public DialogueObject event6;

    // Start is called before the first frame update
    void Start()
    {
        //get resource
        /*GameObject resource = GameObject.Find("player");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();
        //get mission item list
        GameObject craft = GameObject.Find("GameManager");
        Crafting craftingScript = craft.GetComponent<Crafting>();

        missionContent.text = "Repair " + craftingScript.missionList[craftingScript.current].itemName;

        Debug.Log("the number is " + craftingScript.missionList.Count);*/
    }

    void Update()
    {
        //get resource
        GameObject resource = GameObject.Find("GameManager");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();
        //get mission item list
        GameObject craft = GameObject.Find("GameManager");
        Crafting craftingScript = craft.GetComponent<Crafting>();

        GameObject gameManager = GameObject.Find("GameManager");
        DialogueSystem dialogueScript = gameManager.GetComponent<DialogueSystem>();

        if (craftingScript.current == 1 && firstHull == false)
        {
            craftingScript.closeCrafting();
            dialogueScript.startDialogue(event5);
            firstHull = true;
        }

        if (craftingScript.current >= craftingScript.missionList.Count && firstEngine == false)
        {
            craftingScript.closeCrafting();
            dialogueScript.startDialogue(event6);
            missionContent.text = "Return to the ship to escape";
            escape = true;
            firstEngine = true;
        }
        else
        {
            missionContent.text = "Repair " + craftingScript.missionList[craftingScript.current].itemName;
        }


    }


}
