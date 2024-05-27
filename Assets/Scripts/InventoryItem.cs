using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public string english_Name;
    public string french_Name;
    public string habrew_Name;
    public Sprite icon;
    public string english_Description;
    public string habrew_Description;
    public string french_Description;

    public int count;
    public bool isUsable = false;
    public UnityEvent itemAction;
    public Vector3 itemPos;
}
