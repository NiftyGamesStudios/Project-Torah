using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public InventoryItem item;
    public Image icon;
    public TMP_Text item_CountText;
    public Sprite[] boarders;
    public Image boarder;
    public int index = 0;

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }
    private void Start()
    {  
        btn.onClick.AddListener(Select_Item);
    }
    public void Initialize_Item(InventoryItem item,int index)
    {
        this.item = item;
        index = this.index;
        icon.sprite = item.icon;
        item_CountText.text = item.count.ToString();
    }
    public void Select_Item()
    {
        foreach (Item item in FindObjectsOfType<Item>())
        {
            item.boarder.sprite = boarders[0];
        }
        
        boarder.sprite = boarders[1];
        FindObjectOfType<InventoryPage>().UpdateDescription(item);
    }

    
}
