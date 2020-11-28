using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevalBlock : InteractionObject
{
    public float x;
    public float y;
    public GameObject block;

    public override void OnInteraction(KeyCode inputKey)
    {
        block.transform.position = new Vector2(x, y);
    }
}
