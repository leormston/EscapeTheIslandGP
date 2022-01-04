using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Typewriter : MonoBehaviour
{
    private float speed = 30f;
    public Coroutine Run(string textToType, Text textLabel) {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, Text textLabel) {
        //ellapsed time
        float t = 0;
        //how many text each frame
        int charIndex = 0;

        while (charIndex < textToType.Length) {

            t += Time.deltaTime * speed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
