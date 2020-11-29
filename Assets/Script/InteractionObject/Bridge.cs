using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : InteractionObject
{
    public Collider2D bridgeColider;
    public GameObject particle;

    SpriteRenderer spriteRender;
    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        bridgeColider.enabled = true;
        spriteRender.enabled = true;
        Destroy(particle);
    }

}
