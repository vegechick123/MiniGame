using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    bool bGameEnd = false;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (bGameEnd)
            return;
        bGameEnd = true;
        this.InvokeAfter(()=>SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1),4f);
        Animator target = Camera.main.GetComponent<Animator>();
        if (target)
            target.SetTrigger("TurnWhite");
    }
}
