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
            tutorialScript.displayAxeTutorial();
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
            tutorialScript.displaySlingerTutorial();
            firstSlinger = true;
        }
    }
}
