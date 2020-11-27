using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool canTrigger=false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            canTrigger = true;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            canTrigger = false;
    }
    public void Update()
    {
        if (canTrigger && Input.GetKeyDown(KeyCode.V))
            OnInteraction();
    }
    public virtual void OnInteraction()
    {
        
    }
}
