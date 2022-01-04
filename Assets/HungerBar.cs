using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    public void SetMaxHunger(int hunger){
        slider.maxValue = hunger;
        slider.value = hunger;

        fill.color = gradient.Evaluate(1f);
    }
    // Start is called before the first frame update
    public void SetHunger(int hunger){
        slider.value = hunger;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
