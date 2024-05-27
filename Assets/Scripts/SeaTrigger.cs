using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class SeaTrigger : MonoBehaviour
{
    public UnityEvent onSeaEvent;
    public string _playerTag;
    public Camera _camera;
    public Vector3 rotationOffset;
    public Vector3 positionOffset;
    public Vector3 positionReset;
    public Vector3 rotationReset;
    public float speed = 5;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(_playerTag))
        {
           onSeaEvent.Invoke();
        }
    }
    public void CameraAnimation(bool Offset)
    {
        if(Offset)
        { //Do camera Animation
            _camera.transform.DORotate(rotationOffset, speed);
            _camera.GetComponent<CameraController>().CameraOffset = positionOffset;
        }
        else
        {
            _camera.transform.DORotate(rotationReset, speed);
            _camera.GetComponent<CameraController>().CameraOffset = positionReset;
        }
        
    }
}
