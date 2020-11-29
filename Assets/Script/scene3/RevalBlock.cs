using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevalBlock : InteractionObject
{
    public float x;
    public float y;
    public GameObject block;
    private bool revaled = false;
    
    public override void OnInteraction(KeyCode inputKey)
    {
        if (revaled) { }
        else { block.transform.position = new Vector2(x, y);
            revaled = true;
        }
        
      
    }

}
