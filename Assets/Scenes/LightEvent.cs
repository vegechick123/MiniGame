using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer; 
    public bool lastFrameHit=false;
    public bool currameHit=false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        this.InvokeNextFixedFrame(LateFixedUpdate);
    }
    private void LateFixedUpdate()
    {
        if (!lastFrameHit&&currameHit)
        {
            OnLightEnter();
        }
        else if(lastFrameHit && !currameHit)
        {
            OnLightOut();
        }

        lastFrameHit = currameHit;
        currameHit = false;
    }
    void OnLightEnter()
    {
        spriteRenderer.color = Color.white;
    }
    void OnLightOut()
    {
        spriteRenderer.color = Color.black;
    }
}
