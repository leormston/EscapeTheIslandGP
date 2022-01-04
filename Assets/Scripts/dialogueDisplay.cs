using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;
using System.Linq;
using TMPro;

public class dialogueDisplay : MonoBehaviour
{
    //dialogue background
    public GameObject dialogueWindow;
    //dialogue text
    public Text dialogueText;
    //name text
    public Text nameText;
    //splash art right
    public GameObject rightArt;
    //splash art left
    public GameObject leftArt;

    //list for generating text
    //public List<string> fileLines;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(event1());

    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(event1());
        if (Keyboard.current.enterKey.wasPressedThisFrame) {
            Debug.Log("keypressed");
        }
    }

    //Event for the first time into the game
    //A briefing of what is happening
    public IEnumerator event1()
    {
        Debug.Log("event1 activated");
        //Name always starts from 0 and + 2 each time
        int name = 0;
        //Text always starts from 1 and + 2 each time
        int text = 1;
        string path = "Assets/event1.txt";
        //Read the text from directly from the test.txt file
        //StreamReader reader = new StreamReader(path);
        string[] lines = File.ReadAllLines(path);
        bool end = false;
        //A while loop going over the event
        while (end != true) {
            Debug.Log("into while");
            //Debug.Log("into while");
            //display content
            nameText.text = lines[name];
            dialogueText.text = lines[text];
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                Debug.Log("keyboard pressed");
                name += 2;
                text += 2;
                if (text < lines.Length)
                {
                    end = true;
                }
            }
            else {
                Debug.Log("key not pressed");
            }
            yield return null;
            Debug.Log("current text is " + text);
        }
        //Debug.Log(reader.ReadLine());
        
        //reader.Close();
    }

}
