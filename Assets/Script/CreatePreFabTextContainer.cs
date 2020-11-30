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
    public Color color;
    public Font font;
    public int fontSize=-1;
    void Awake()
    {
       
        Ins();
    }
    
    void Ins()
    {
        char[] arr = input.ToCharArray();

        Create(arr,true);

    }
    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void Create(char[] arr, bool delay = false, float deltatime = 1f)
    {
        Clear();
        for (int i = 0; i < arr.Length; i++)
        {

            GameObject textCtner = textContainer;
            GameObject ContainTxt =
                    Instantiate(textCtner,
                    new Vector3(TextPreFabContainer.transform.position.x + i * 20, TextPreFabContainer.transform.position.y, 0f),
                    Quaternion.identity) as GameObject;
            ContainTxt.transform.SetParent(TextPreFabContainer.transform);
            Text text = ContainTxt.GetComponentInChildren<Text>();
            text.text = arr[(int)i].ToString();
            if (font != null)
                text.font = font;
            if (fontSize >0)
                text.fontSize = fontSize;
            text.color = color;
        }
    }

}
