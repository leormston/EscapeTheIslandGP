using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoard : MonoBehaviour
{
    public Text missionContent;
    public bool escape = false;
        
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

    void Update() {
        //get resource
        GameObject resource = GameObject.Find("GameManager");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();
        //get mission item list
        GameObject craft = GameObject.Find("GameManager");
        Crafting craftingScript = craft.GetComponent<Crafting>();

        if (craftingScript.current >= craftingScript.missionList.Count)
        {
            missionContent.text = "Return to the ship to escape";
            escape = true;
        }
        else {
            missionContent.text = "Repair " + craftingScript.missionList[craftingScript.current].itemName;
        }
        

    }

    
}
