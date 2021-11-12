using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayInteraction : MonoBehaviour
{
    RaycastHit hit;

    public GameObject interaction;

    public Text content;


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
        if (playerScript.uiOn == false) {
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
                else if (missionScript.escape && hit.collider.name.Contains("Ship")) {
                    content.text = "ship, press E to escape";
                    interaction.SetActive(true);
                }
                else {
                    interaction.SetActive(false);
                }
            }
        }
            
    }
}
