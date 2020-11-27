using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public Vector3[] position;
    public float[] rotation;    
    public int curIndex=0;
    void Refresh(int targetIndex)
    {
        if (0 <= targetIndex && targetIndex < position.Length)
        {
            transform.position = position[targetIndex];
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation[targetIndex]));
            curIndex = targetIndex;
        }
    }
    public void ChangeIndex(int chageValue)
    {
        int targetIndex = Mathf.Clamp(curIndex + chageValue,0, position.Length);
        if(targetIndex!=curIndex)
        {
            Refresh(targetIndex);
        }
    }
}
