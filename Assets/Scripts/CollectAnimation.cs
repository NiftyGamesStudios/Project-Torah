using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;

public class CollectAnimation : MonoBehaviour
{
    //References
    [Header("UI references")]
    [SerializeField] GameObject animatedItemPrefab;
    [SerializeField] Transform target;

    [Space]
    [Header("Available items : (items to pool)")]
    [SerializeField] int maxItems;
    Queue<GameObject> ItemsQueue = new Queue<GameObject>();


    [Space]
    [Header("Animation settings")]
    [SerializeField][Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField][Range(0.9f, 2f)] float maxAnimDuration;

    [SerializeField] Ease easeType;
    [SerializeField] float spread;

    Vector3 targetPosition;


    private int _c = 0;

   /* public int Coins
    {
        get { return _c; }
        set
        {
            _c = value;
            //update UI text whenever "Coins" variable is changed
          //  itemUIText.text = Coins.ToString();
        }
    }*/

    void Awake()
    {
        targetPosition = target.position;

        //prepare pool
        PrepareItems();
    }

    void PrepareItems()
    {
        GameObject item;
        for (int i = 0; i < maxItems; i++)
        {
            item = Instantiate(animatedItemPrefab);
            item.transform.parent = transform;
            item.SetActive(false);
            ItemsQueue.Enqueue(item);
        }
    }

    void Animate(Vector3 collectedItemPosition, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //check if there's coins in the pool
            if (ItemsQueue.Count > 0)
            {
                //extract a coin from the pool
                GameObject Item = ItemsQueue.Dequeue();
                Item.SetActive(true);

                //move coin to the collected coin pos
                Item.transform.position = collectedItemPosition + new Vector3(Random.Range(-spread, spread), 0f, 0f);

                //animate coin to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                Item.transform.DOMove(targetPosition, duration)
                .SetEase(easeType)
                .OnComplete(() => {
                    //executes whenever coin reach target position
                    Item.SetActive(false);
                    ItemsQueue.Enqueue(Item);

                });
            }
        }
    }

    public void AddItem(Vector3 collectedCoinPosition, int amount)
    {
        Animate(collectedCoinPosition, amount);
    }
}