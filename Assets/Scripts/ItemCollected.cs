using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollected : MonoBehaviour
{
    public InventoryItem item;

    public GameObject itemGameObject;
    public InventoryPage inventory;
    public int itemIndex;
    [SerializeField] private AudioSource sound;
    public void Collect()
    {
        inventory.AddItem(itemIndex);
        itemGameObject.SetActive(false);    
        sound.Play();
    }
}
