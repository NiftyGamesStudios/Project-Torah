using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDestruct : DamageOnTouch
{
    protected override void Colliding(Collider2D collider)
    {

        base.Colliding(collider);

        //Debug.Log("Colliding With Something.");
        Destroy(gameObject);
    }
}
