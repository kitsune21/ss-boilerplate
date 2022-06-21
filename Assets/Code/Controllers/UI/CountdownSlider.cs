using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSlider : MonoBehaviour
{
    private Slider slider;
    private bool isAppreciating;
    private bool isDepreciating;
    private bool resetOnCompletion;

    public Color startColor;
    public Color endColor;
    public Image backGroundColor;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        updateSliderValue();
    }

    private void updateSliderValue() {
        if(isAppreciating) {
            if(slider.value < slider.maxValue) {
                slider.value += Time.deltaTime;
            } else {
                if(resetOnCompletion) {
                    slider.value = slider.minValue;
                }
            }
        } else if(isDepreciating) {
            if(slider.value > slider.minValue) {
                slider.value -= Time.deltaTime;
            } else {
                if(resetOnCompletion) {
                    slider.value = slider.maxValue;
                }
            }
        }
    }

    //---------------------------------------------------Setters---------------------------------------------//
    public void setMaxValue(float newMaxValue) {
        slider.maxValue = newMaxValue;
    }

    public void setMinValue(float newMinValue) {
        slider.minValue = newMinValue;
    }

    public void setMaxValueFromInput(string newMaxValue) {
        slider.maxValue = float.Parse(newMaxValue);
    }

    public void setMinValueFromInput(string newMinValue) {
        slider.minValue = float.Parse(newMinValue);
    }

    //---------------------------------------------------Public Methods---------------------------------------------//

    public void startAppreciating(bool reset = false) {
        isAppreciating = true;
        isDepreciating = false;
        resetOnCompletion = reset;
    }

    public void startDepreciating(bool reset = false) {
        isAppreciating = false;
        isDepreciating = true;
        resetOnCompletion = reset;
    }
}
