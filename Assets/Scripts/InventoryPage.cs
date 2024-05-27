using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPage : MonoBehaviour
{

    public GameObject inventroy;
    public Item itemPrefab;
    public InventoryItem[] items;

    public Button use_ItemBtn, throw_ItemBtn;

    public Transform content;
    List<Item> itemsList = new List<Item>();

    public Image item_Image;
    public TMP_Text description;
    public TMP_Text english_Name, french_Name, Habrew_Name;
    private Transform content_ItemNotification;
    public GameObject notificationItem_Text;

    private void Start()
    {
        InitializeInventoryUI();
        content_ItemNotification = GameObject.Find("ItemInput").transform;
        UpdateDescription(items[0]);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Show();
        }
    }
    public void UpdateDescription(InventoryItem item)
    {
        item_Image.sprite = item.icon;
        description.text = item.english_Description;
        english_Name.text = "<b>English</b>\n" +item.english_Name;
        french_Name.text = "<b>Français</b>\n" + item.french_Name;
        Habrew_Name.text = "<b>עברית</b>\n" + item.habrew_Name;
        if (!item.isUsable)
        {
            use_ItemBtn.interactable = false;
        }

        else
        {
            use_ItemBtn.interactable = true;
            use_ItemBtn.onClick.RemoveAllListeners();
            use_ItemBtn.onClick.AddListener(() => item.itemAction.Invoke());
        }            
    }

    public void InitializeInventoryUI()
    {
        ClearInventoryItems();
        for (int i = 0; i < items.Length; i++)
        {
            Item item = Instantiate(itemPrefab, content.transform);
            Item itemCom = item.GetComponent<Item>();
            itemCom.Initialize_Item(items[i], i);
            //  item.transform.SetParent(content.transform);
            if (item.item.count > 0)
            {
                itemsList.Add(item);
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }

        }
    }

    private void ClearInventoryItems()
    {
        // Efficiently remove existing children using a loop or List.Clear()
        if (content.transform.childCount > 0)
        {
            int childCount = content.transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                Destroy(content.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            itemsList.Clear(); // Clear the list if no children exist
        }
    }


    public void Show()
    {
        inventroy.SetActive(true);
        InitializeInventoryUI();
    }
    public void AddItem(int item_Index)
    {
        GameObject text = Instantiate(notificationItem_Text, content_ItemNotification);
        text.GetComponent<TMP_Text>().text = items[item_Index].english_Name+" picked";
    
        items[item_Index].count++;
    }
}
