using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : InteractionObject
{
    public GameObject breakParticle;
    //Collider2D colider; 
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        Instantiate(breakParticle, gameObject.transform.position, breakParticle.transform.rotation);
        gameObject.SetActive(false);
 
    }

}
