using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPositionSetter : MonoBehaviour
{
    public GameObject ps;

    public void Collect()
    {
        var particle = Instantiate(ps,this.transform.position,Quaternion.identity);
        Destroy(particle,5);
    }
}
