using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Form
{
    Light,
    Shadow,
    Any
}
public class LightShadowForm : LightEvent
{
    public Form state=Form.Light;

    public override void OnLightEnter()
    {
        base.OnLightEnter();
        spriteRenderer.color = Color.white;
        state = Form.Light;
    }
    public override void OnLightOut()
    {
        base.OnLightOut();
        spriteRenderer.color = Color.black;
        state = Form.Shadow;
    }
}
