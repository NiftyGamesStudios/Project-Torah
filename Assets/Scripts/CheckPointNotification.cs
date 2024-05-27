using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointNotification : MonoBehaviour
{
    
    public TMP_Text coins;
    public TMP_Text book;
    public Image bookImage;
    public Sprite[] images;

    public void ShowScreen(int index)
    {
        InventoryPage inventoryPage = FindAnyObjectByType<InventoryPage>();
       
        coins.text = inventoryPage.items[7].count.ToString();
        bookImage.sprite = inventoryPage.items[index].icon;
        if (inventoryPage.items[index].count == 0)
        {
            book.text = "Left";
        }
        else
            book.text = "Collected";

        this.Wait(3, () => { this.gameObject.SetActive(false); });
    }
}
