using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public Form activeState;
    public KeyCode interationKey=KeyCode.V;
    [HideInInspector]
    public bool canTrigger=false;
    public LightShadowForm player; 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = GetComponent<LightShadowForm>();
            canTrigger = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = null;
            canTrigger = false;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            OnInteraction(KeyCode.M);
        if (canTrigger && Input.GetKeyDown(interationKey)&&(player.state==activeState||activeState==Form.Any))
            OnInteraction(interationKey);
    }
    public virtual void OnInteraction(KeyCode inputKey)
    {
        
    }
}
