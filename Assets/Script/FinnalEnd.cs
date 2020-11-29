using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinnalEnd : MonoBehaviour
{
    public string[] dialog;
    public CreatePreFabTextContainer createPreFabTextContainer;
    public int index = -1;
    public Text targetText;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        MovePlayer target = collision.gameObject.GetComponent<MovePlayer>();
        if (target != null)
            target.disableInput = true;
        if (index == -1)
        {
            targetText.text = dialog[++index];
            Camera.main.GetComponent<Animator>().SetTrigger("FinalBegin");
        }
    }
    void Update()
    { 
        if(Input.anyKeyDown)
        {
            if (0 <= index && index + 1 < dialog.Length)
                targetText.text=dialog[++index];
            else if(index + 1 >= dialog.Length)
            {
                targetText.text = "";
                this.InvokeAfter(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1), 4f);
                Camera.main.GetComponent<Animator>().SetTrigger("TurnBlack");
            }
        }
    }

}
