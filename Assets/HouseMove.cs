using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMove : MonoBehaviour
{
    public float speed = 10f;
    public float lastPosition;
    public Ease ease = Ease.OutBounce;

    public BoxCollider2D boxCollider;

    public void MoveHouse()
    {
        transform.DOMoveZ(lastPosition, speed).SetEase(ease).
            OnComplete(()=> 
            boxCollider.enabled = true
            );
       
    }
}
