using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject[] panels;
    private void Awake()
    {
        instance = this;
       // OpenPanel(0);
    }

    public void OpenPanel(int index)
    {
        foreach (GameObject go in panels)
        {
            if(go.activeSelf)
            go.GetComponent<FadeInOut>().Hide();
        }
        panels[index].SetActive(true);
       
    }
    public void ResetPP()
    {
        PlayerPrefs.DeleteAll();
    }
    public void OnClick_Quit()
    {
        Application.Quit();
    }
}
