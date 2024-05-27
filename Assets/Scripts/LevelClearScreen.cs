using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelClearScreen : MonoBehaviour
{
    public TMP_Text coins;
    public TMP_Text book;

    public void ShowScreen()
    {
        InventoryPage inventoryPage = FindAnyObjectByType<InventoryPage>();
        coins.text = inventoryPage.items[7].count.ToString();
        int bookCount = 0;
        for (int i = 0; i < 5; i++)
        {
            if(inventoryPage.items[i].count > 0)
                bookCount++;
        }

        book.text = bookCount+"/5";

      //  this.Wait(3, () => { this.gameObject.SetActive(false); });
    }
}
