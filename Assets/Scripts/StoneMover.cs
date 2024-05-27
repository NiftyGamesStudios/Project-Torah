using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMover : MonoBehaviour
{
    public float speed = 5f;
    public AudioSource sound;
    public Transform[] stones;


    public void StonesCall()
    {
        StartCoroutine(AnimateStones());
    }
    IEnumerator AnimateStones()
    {

        for (int i = 0; i < stones.Length; i++)
        {
            StoneMove(stones[i], 2);
            yield return new WaitForSeconds(speed);
        }
    }
    private void StoneMove(Transform stone, float move)
    {
        sound.Play();
        stone.DOMoveY(move, speed).OnComplete(sound.Stop);
    }
}
