using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineUpDown : InteractionObject
{
    public Collider2D lightCollider;
    public Gear targetGear;
    public int chageIndex = 1;
    private bool judge = false;
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        targetGear.ChangeIndex2(chageIndex);
        Debug.Log(transform.position);
        if (judge == true)
            lightCollider.enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        judge = true;
    }
}
