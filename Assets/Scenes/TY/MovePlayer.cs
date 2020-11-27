using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;


    private bool isGround;
    private Rigidbody2D rb2d;
    private Vector2 targetPos = new Vector2(-6, -0.6851993f);
    private Vector2 currentPos = new Vector2(-6, -0.6851993f);
    private Animator animator;
    private GameObject Player;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        bool ver = Input.GetKeyDown(KeyCode.Space);
        if (ver && isGround)
        {

            rb2d.velocity=new Vector2(0,5.0f);
            //if(!Input .GetKeyDown ("right")||!Input .GetKeyDown ("left"))
            //animator.SetTrigger("isJump");
        }
       
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);       
            transform.localScale = new Vector2(1f, 1f);
            animator.SetTrigger("isRun");
        }        
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y); 
            transform.localScale = new Vector2(-1f, 1f);
            animator.SetTrigger("isRun");
        }
        else
        {
           rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        animator.SetTrigger("isIdle");

    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isGround = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
            isGround = true;
        }
}
    

    



 