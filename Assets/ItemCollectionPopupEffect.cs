using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectionPopupEffect : MonoBehaviour
{
    public static ItemCollectionPopupEffect Instance;

    public RectTransform panel;

    public TMP_Text itemName;
    public Image itemImage;

    public Ease ease = Ease.OutBounce;


    private void Awake()
    {
        Instance = this;
    }
    public void PopMenu(InventoryItem item,float delay = 0.3f)
    {
        itemName .text = item.name+ " is Collected.";
        itemImage.sprite = item.icon;

        panel.DOScale(new Vector2(1, 1), delay).SetEase(ease);
        this.Wait(delay, () =>itemImage.GetComponent<RectTransform>().DOScale(new Vector2(1, 1), delay).SetEase(ease).OnComplete(CloseMenu));
    }

    public void CloseMenu()
    {
        this.Wait(1,()=>panel.DOScale(Vector2.zero, .5f).SetEase(ease));
    }
}
