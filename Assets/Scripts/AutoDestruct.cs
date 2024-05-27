using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    public float delay = 2;
    // Start is called before the first frame update
    void Start()
    {
        this.Wait(this.delay,()=> Destroy(gameObject));
    }

  
}
