using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : InteractionObject
{
    public Gear targetGear;
    public int chageIndex = 1;
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        targetGear.ChangeIndex(chageIndex);
       
        
    }
}
