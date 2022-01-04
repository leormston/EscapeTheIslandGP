using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject GameUI;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("pressed escape");
            if(GameIsPaused){
                Resume();
            }
            else{
                GameObject gameManager = GameObject.Find("GameManager");
                DialogueSystem dialogueScript = gameManager.GetComponent<DialogueSystem>();
                if (dialogueScript.diaOn == false) {
                    Pause();
                }
            }
        }
    }

    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject player = GameObject.Find("Player");
        Movement playerScript = player.GetComponent<Movement>();
        playerScript.uiOn = false;
    }

    void Pause(){
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject player = GameObject.Find("Player");
        Movement playerScript = player.GetComponent<Movement>();
        playerScript.uiOn = true;
    }

    public void LoadSettings(){
        Debug.Log("Opening settings");
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
