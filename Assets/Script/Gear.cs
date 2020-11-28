using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public Vector3[] position;
    public float[] rotation;    
    public int curIndex=0;
    public int curIndex2 = 0;
    public int curIndex3 = 0;
    public int max = 10;
  
    void Refresh(int targetIndex)
    {
        if (0 <= targetIndex && targetIndex < position.Length)
        {
            transform.localPosition= position[targetIndex];
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotation[targetIndex]));
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
   void MoveVer(int targetIndex)
    {
        Vector3 pos = transform.position;
        pos.y += targetIndex;
        
            transform.position = pos;          
            curIndex2 = targetIndex;
        
       
    }
    public void ChangeIndex2(int chageValue)
    {
        int targetIndex = Mathf.Clamp(curIndex2 + chageValue, 0, max);
        if (targetIndex != curIndex2)
        {
            MoveVer(targetIndex);
        }
    }
    void MoveHor(int targetIndex)
    {
        Vector3 pos = transform.position;
        pos.x += targetIndex;

        transform.position = pos;
        curIndex3 = targetIndex;


    }
    public void ChangeIndex3(int chageValue)
    {
        int targetIndex = Mathf.Clamp(curIndex3 + chageValue, 0, max);
        if (targetIndex != curIndex3)
        {
            MoveHor(targetIndex);
        }
    }
}
