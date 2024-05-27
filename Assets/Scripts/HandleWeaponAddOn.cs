using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using UnityEngine.Events;

public class HandleWeaponAddOn : CharacterHandleWeapon
{
    public bool weaponsHolding;
    public InventoryItem[] weaponsInventory;
    public UnityEvent onEventCall;

    public GameObject[] weaponToBeActive;
    public Weapon[] weapons;

  
    private void LateUpdate()
    {
        for(int i = 0; i < weaponsInventory.Length; i++) 
        {
            if (weaponsInventory[i].count < 0)
                return;

            if (!weaponsInventory[i].isUsable)
            {
                weaponsInventory[i].isUsable = true;
                weaponsInventory[i].itemAction.AddListener(()=> HoldWeapon(i));
            }              
        }           
    }

    public void HoldWeapon(int index)
    {
        weaponsHolding = true;
        weaponToBeActive[index].SetActive(true);
        ChangeWeapon(weapons[index], null);
    }
}
