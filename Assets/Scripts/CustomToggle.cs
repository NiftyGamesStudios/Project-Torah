using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    public bool isOn = false;
    public RectTransform toggleNob;
    public Image toggleBgImage;
    public Sprite[] toggleBgSprite;
    public Sprite[] toggleNobSprite;
    

    public void Toggle()
    {
        isOn = !isOn;
        if (isOn)
        {
            toggleNob.anchoredPosition = Vector3.right * 50;
            toggleNob.GetComponent<Image>().sprite = toggleNobSprite[0];
            toggleBgImage.sprite = toggleBgSprite[0];
        }
        else
        {
            toggleNob.anchoredPosition = Vector3.right * -50;
            toggleNob.GetComponent<Image>().sprite = toggleNobSprite[1];
            toggleBgImage.sprite = toggleBgSprite[1];
        }
           
    }
}
