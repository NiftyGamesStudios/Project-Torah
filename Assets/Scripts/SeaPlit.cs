using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeaPlit : MonoBehaviour
{
    public Transform sea1, sea2;
    public float splitSpeed = 10f;
    public AudioSource seaSource;
    public ParticleSystem seaEmitor;
    public GameObject collider;


    public void OpenSea()
    {
        seaSource = GetComponent<AudioSource>();
        sea1.DOLocalMoveY(0.0009f, splitSpeed);
       
        sea2.DOLocalMoveY(-0.01651f, splitSpeed).OnComplete(() =>
        {
            collider.SetActive(false);
            seaSource.Stop();
        });
        seaSource.Play();
        // seaEmitor.Play();
    }
}
