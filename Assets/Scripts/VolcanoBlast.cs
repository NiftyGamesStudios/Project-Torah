using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBlast : MonoBehaviour
{
    public ParticleSystem ps;
    private bool isPlaying = false;
    private float timer = 0f;
    public float playDuration = 3f;
    public float stopDuration = 3f;
    BoxCollider2D hitMark;

    private void Start()
    {
        hitMark = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (!isPlaying && timer >= stopDuration)
        {
            ps.Play();
            isPlaying = true;
            
            timer = 0f;
        }
        else if (isPlaying && timer >= playDuration)
        {
            ps.Stop();
            isPlaying = false;
            timer = 0f;
        }
        hitMark.enabled = isPlaying;
    }
}
