using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : InteractionObject
{
    //Collider2D colider; 
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        gameObject.SetActive(false);
    }

}
