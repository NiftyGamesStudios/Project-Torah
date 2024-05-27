using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabBar : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] statusSprites;
    public GameObject[] menus;
    public Color[] menusColor;


    public void ChangeMenu(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            menus[i].SetActive(false);
            statusSprites[i].SetActive(false);
            buttons[i].GetComponent<TMP_Text>().color = menusColor[0];
        }
        buttons[index].GetComponent<TMP_Text>().color = menusColor[1];
        menus[index].SetActive(true);
        statusSprites[index].SetActive(true);
    }
}
