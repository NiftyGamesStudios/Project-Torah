using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour
{
    public TMP_Text text;
    public Slider slider;
    public Color[] colors = new Color[2];

    public void OnValueChange()
    {
        text.text = slider.value.ToString("0");

        if(slider.value > 0)
            text.color = colors[0];
        else text.color = colors[1];
    }
}
