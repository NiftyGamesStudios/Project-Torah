using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundTrigger : MonoBehaviour
{
    public string targetTag = "Player";
    public Transform buttonMesh;

    private bool isPressed;

    [Space]
    [Header("Tiles")]
    public Transform[] TilesToMove;
    public float tileFinalPosition, tileInitialPosition;
    public float tileMovementTime = 1.5f;
    public float delayBetweenTiles = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
   
            buttonMesh.DOMoveY(-7.9f, 0.1f);
            isPressed = true;
            MoveTiles();
        
    }

    private void Update()
    {
        // We will handle the tile movement in MoveTiles method
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       
            buttonMesh.DOMoveY(-7.5f, 0.1f);
            isPressed = false;
            MoveTiles();
      
    }

    private void MoveTiles()
    {
        Sequence tileSequence = DOTween.Sequence();
        if (isPressed)
        {
            for (int i = 0; i < TilesToMove.Length; i++)
            {
                Transform t = TilesToMove[i];
                tileSequence.Insert(i * delayBetweenTiles, t.DOMoveY(tileFinalPosition, tileMovementTime).SetEase(Ease.Flash));
            }
        }
        else
        {
            for (int i = 0; i < TilesToMove.Length; i++)
            {
                Transform t = TilesToMove[i];
                tileSequence.Insert(i * delayBetweenTiles, t.DOMoveY(tileInitialPosition, tileMovementTime).SetEase(Ease.Flash));
            }
        }
    }
}
