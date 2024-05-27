using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryNotification : MonoBehaviour
{
    public TMP_Text text;

    public void InitizlizeNotification(string content)
    {
        text.text = content;
    }
}
