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
    public Animator animator;

    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
    public override void OnLightEnter()
    {
        base.OnLightEnter();
        state = Form.Light;
        animator.SetTrigger("ToLight");
        animator.SetBool("Light",true);
    }
    public override void OnLightOut()
    {
        base.OnLightOut();
        //spriteRenderer.color = Color.black;
        state = Form.Shadow;
        animator.SetTrigger("ToShadow");
        animator.SetBool("Light", false);
    }
}
