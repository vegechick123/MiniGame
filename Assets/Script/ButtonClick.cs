using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonClick : MonoBehaviour
{
   
    // Start is called before the first frame update
    public void Click()
    {
        Debug.Log("enterGame");
        SceneManager.LoadScene(1);
        
    }
    public void Click2()
    {
        Application.Quit();
    }

        
  }
    

