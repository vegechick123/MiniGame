using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : InteractionObject
{
    public GameObject breakParticle;
    public AudioClip sound;
    //Collider2D colider; 
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        Instantiate(breakParticle, gameObject.transform.position, breakParticle.transform.rotation);
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, 1.0f);
        gameObject.SetActive(false);
 
    }

}
