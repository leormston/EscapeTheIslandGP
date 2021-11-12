using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hungerReduce : MonoBehaviour
{   
    //hunger
    public int hunger = 100;
    public int counter;

    //the hunger text
    public Text hungerText;

    public void hungerIncrease() {
        //test if hunger is not 100 yet
        if (hunger <= 100) {
            //if the hunger is over 100 set it to 100
            if (hunger + 5 >= 100)
            {
                hunger = 100;
            }
            //else +5 hunger
            else {
                hunger += 5;
            }
            hungerText.text = "Hunger: " + hunger.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //counter reduce hunger every 3 second
        counter++;
        if (counter == 3000) {
            hunger--;
            hungerText.text = "Hunger: " + hunger.ToString();
            counter = 0;
        }
        if (hunger == 0) {
            GameObject gameManager = GameObject.Find("GameManager");
            GameOver gameOverScript = gameManager.GetComponent<GameOver>();
            gameOverScript.displayGameOver(2);
        }
    }
}
