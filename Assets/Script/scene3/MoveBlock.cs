using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : InteractionObject
{
    public float xMove;
    public int moveSpeed;
    public GameObject block;
    private bool moving= false;
    private int counter = 0;


    public override void OnInteraction(KeyCode inputKey)
    {
        moving = true;
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            if (counter <= moveSpeed)
            {
                float positionChange = xMove / moveSpeed;
                block.transform.position = new Vector2(block.transform.position.x + positionChange, block.transform.position.y);
                counter++;
            }
            else
            {
                counter = 0;
                moving = false;
            }
        }

    }

}
