using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrigger : MonoBehaviour
{
    public string _PlayerTag = "Player";
    public AudioSource _AudioSource;
    public AudioClip _AudioClip;
    public AudioClip _WindClip;
    public AudioSource _WindAudioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == _PlayerTag)
        {
            ObjectSpawner os = FindObjectOfType<ObjectSpawner>();
            os.canThrow = true;
            if (os.canThrow)
            {
                _AudioSource.clip = _AudioClip;
                _WindAudioSource.clip = _WindClip;
            }
        }
            

    }
}
