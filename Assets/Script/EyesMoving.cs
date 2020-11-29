using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMoving : MonoBehaviour
{
    public GameObject player;
    public float moveAbandonRadius;
    public float eyesMoveSpeed;


    private Vector3 startPos;
    private Vector3 dir;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Debug.Log(this.transform.position);
        dir = startPos - player.transform.position;
        dir = dir.normalized;
        this.transform.position = Vector2.MoveTowards(this.transform.position, startPos  - dir * moveAbandonRadius,eyesMoveSpeed);
    }
}
