using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public GameObject crafting;
    public Button close;
    public Text axeRequirement;
    public Button craftAxe;
    public Text slingShotRequirement;
    public Button craftSlingShot;
    public Text missionName;
    public Text missionRequirement;
    public Button craftMission;
    public List<CraftableItem> missionList;
    public int current = 0;

    //amount for mission
    //private int[] missionAmount = { };

    //mission required material



    // Start is called before the first frame update
    void Start()
    {
        //set crafting menu unseen (initial)
        crafting.SetActive(false);

        //create the mission item list
        CraftableItem hull = new CraftableItem("Hull", 3, 0, 0);
        missionList.Add(hull);
        CraftableItem engine = new CraftableItem("Engine", 5, 5, 20);
        missionList.Add(engine);

        close.onClick.AddListener(closeCrafting);
        craftMission.onClick.AddListener(checkRequirement);
        craftAxe.onClick.AddListener(checkStoneAxeRequirement);
        craftSlingShot.onClick.AddListener(checkSlingerShotRequirement);

    }

    //open crafting menu
    public void openCrafting() {
        crafting.SetActive(true);
        displayRequirement();
    }

    void displayRequirement() {
        //get resource class
        GameObject resource = GameObject.Find("GameManager");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();

        

        axeRequirement.text = resourceScript.stone + "/3 stone, " + resourceScript.wood + "/1 wood";
        slingShotRequirement.text = resourceScript.stone + "/3 scrap, " + resourceScript.wood + "/1 wood";
        string wood = "";
        string stone = "";
        string scrap = "";
        if (current < missionList.Count)
        {
            missionName.text = missionList[current].itemName;
            //for mission, 3 if to produce a string for requirement
            if (missionList[current].woodRequired != 0)
            {
                wood = resourceScript.wood.ToString() + "/" + missionList[current].woodRequired.ToString() + "wood, ";
            }
            if (missionList[current].stoneRequired != 0)
            {
                stone = resourceScript.stone.ToString() + "/" + missionList[current].stoneRequired.ToString() + "stone, ";
            }
            if (missionList[current].scrapRequired != 0)
            {
                scrap = resourceScript.scrap.ToString() + "/" + missionList[current].scrapRequired.ToString() + "scrap";
            }
            //change displayed word
            missionRequirement.text = wood + stone + scrap;
        }
        else {
            missionName.text = "Escape the island";
            missionRequirement.text = "return to the ship";
        }

    }

    void checkRequirement() {
        GameObject resource = GameObject.Find("GameManager");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();
        //check if condition met to craft
        if (current < missionList.Count) {
            if (missionList[current].woodRequired <= resourceScript.wood && missionList[current].stoneRequired <= resourceScript.stone && missionList[current].scrapRequired <= resourceScript.scrap)
            {

                resourceScript.wood -= missionList[current].woodRequired;
                resourceScript.stone -= missionList[current].stoneRequired;
                resourceScript.scrap -= missionList[current].scrapRequired;
                //Debug.Log(missionList[current].scrapRequired);
                current++;
                Debug.Log("the current node is" + current);
                displayRequirement();
            }
        }
        
    }

    //fixed version of stone axe haha, better do it like the mission list using class
    void checkStoneAxeRequirement()
    {
        GameObject resource = GameObject.Find("GameManager");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();
        if (1 <= resourceScript.wood && 3 <= resourceScript.stone)
        {
            resourceScript.stoneAxe += 1;
            resourceScript.stone -= 3;
            resourceScript.wood -= 1;
            displayRequirement();
        }
    }
    //copy from axe very fixed need to change later after prototype
    void checkSlingerShotRequirement()
    {
        GameObject resource = GameObject.Find("GameManager");
        ResourceCounter resourceScript = resource.GetComponent<ResourceCounter>();
        if (1 <= resourceScript.wood && 3 <= resourceScript.scrap)
        {
            resourceScript.slingShot += 1;
            resourceScript.scrap -= 3;
            resourceScript.wood -= 1;
            displayRequirement();
        }
    }

    public void closeCrafting()
    {
        crafting.SetActive(false);
        GameObject PlayerController = GameObject.Find("Player");
        Movement playerScript = PlayerController.GetComponent<Movement>();
        playerScript.uiOn = false;
        Debug.Log("close menu");
    }
}
