using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public Text content;

    public GameObject DeathScreenUI;
    public GameObject GameUI;

    public Image bg;

    public void displayGameOver(int condition) {
        GameObject player = GameObject.Find("Player");
        Movement playerScript = player.GetComponent<Movement>();
        gameOver.SetActive(true);
        playerScript.uiOn = true;
        if (condition == 1)
        {
            PlayerDied();
        }
        else if (condition == 2)
        {
            PlayerStarved();
        }
        else {
            PlayerEscaped();
        }
    }

    public void PlayerDied() {
        content.text = "YOU DIED";
        Cursor.lockState = CursorLockMode.None;
        DeathScreenUI.SetActive(true);
        GameUI.SetActive(false);
        bg.color = new Color32(255,0,0,100);
    }

    public void PlayerStarved() {
        content.text = "STARVED TO DEATH";
        Cursor.lockState = CursorLockMode.None;
        DeathScreenUI.SetActive(true);
        GameUI.SetActive(false);
        bg.color = new Color32(255,0,0,100);
    }

    public void PlayerEscaped() {
        content.text = "YOU'VE ESCAPED THE ISLAND";
        Cursor.lockState = CursorLockMode.None;
        DeathScreenUI.SetActive(true);
        GameUI.SetActive(false);
        bg.color = new Color32(255,255,255,100);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
