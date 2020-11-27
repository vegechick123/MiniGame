using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : InteractionObject
{
    public Vector3[] position;
    public float[] rotation;
    public Transform targetTransform;
    public int curIndex=0;
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        int targetIndex = curIndex + 1;
        if(0<=targetIndex&& targetIndex<position.Length)
        {
            targetTransform.position = position[targetIndex];
            targetTransform.rotation = Quaternion.Euler(new Vector3(0,0,rotation[targetIndex]));
            curIndex = targetIndex;
        }
    }
}
