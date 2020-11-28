using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineLeftRight : InteractionObject
{
   
    public Gear targetGear;
    public int chageIndex = 1;
    private bool judge=false;
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        targetGear.ChangeIndex3(chageIndex);
        Debug.Log(transform.position);
        
    }
    
}
