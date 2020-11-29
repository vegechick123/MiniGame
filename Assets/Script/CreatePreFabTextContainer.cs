using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePreFabTextContainer : MonoBehaviour
{
    public string input;
    List<Text> text;
    public GameObject textContainer;
    public GameObject TextPreFabContainer;
    void Awake()
    {
       
        Ins();
    }
    
    void Ins()
    {
        char[] arr = input.ToCharArray();

        for (int i = 0; i < arr.Length; i++)
        {

            GameObject textCtner = textContainer;
            GameObject ContainTxt =
                    Instantiate(textCtner, new Vector3(TextPreFabContainer.transform.position.x + i * 20, TextPreFabContainer.transform.position.y, 0f), Quaternion.identity)as GameObject ;
            ContainTxt.transform.SetParent(TextPreFabContainer.transform);
            ContainTxt.GetComponentInChildren<Text>().text = arr[(int)i].ToString();
            
        }

    }

}
