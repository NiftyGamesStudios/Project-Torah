using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public InventoryItem coin;
    public TMP_Text coinText;
    public float repeatRate = 1;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateCoin),0.1f,repeatRate);
    }
    void UpdateCoin()
    {
        coinText.text = coin.count.ToString();
    }
}
