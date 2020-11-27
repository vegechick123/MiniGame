using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : InteractionObject
{
    Collider2D bridgeColider;
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        bridgeColider.enabled = true;
    }

}
