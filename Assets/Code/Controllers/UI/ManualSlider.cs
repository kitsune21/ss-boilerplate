using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualSlider : MonoBehaviour
{
    private Slider slider;
    private float currentSetValue;
    private bool isSliding;
    private float lerpWindow = 0.5f;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update() {
        updateSliderValue();
    }

    private void updateSliderValue() {
        if(isSliding) {
            if(slider.value < currentSetValue && slider.value + lerpWindow >= currentSetValue) {
                slider.value = currentSetValue;
                isSliding = false;
            } else if(slider.value > currentSetValue && slider.value - lerpWindow <= currentSetValue) {
                slider.value = currentSetValue;
                isSliding = false;
            } else {
                slider.value = Mathf.Lerp(slider.value, currentSetValue, Time.deltaTime);
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

    public void setCurrentValue(float newValue) {
        currentSetValue = newValue;
        isSliding = true;
    }
}
