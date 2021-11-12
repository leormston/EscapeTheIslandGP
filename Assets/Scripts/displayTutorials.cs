using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayTutorials : MonoBehaviour
{
    public GameObject axeTutorial;

    public GameObject slingerTutorial;


    public void displayAxeTutorial() {
        axeTutorial.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(5, axeTutorial));
    }

    public void displaySlingerTutorial()
    {
        slingerTutorial.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(5, slingerTutorial));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        Debug.Log("the object is" + obj);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

}
