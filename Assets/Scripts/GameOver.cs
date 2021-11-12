using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public Text content;

    public void displayGameOver(int condition) {
        GameObject player = GameObject.Find("Player");
        Movement playerScript = player.GetComponent<Movement>();
        gameOver.SetActive(true);
        playerScript.uiOn = true;
        if (condition == 1)
        {
            content.text = "YOU DIED";
        }
        else if (condition == 2)
        {
            content.text = "STARVE TO DEATH";
        }
        else {
            content.text = "YOU ESCAPED THE ISLAND";
        }
    }
}
