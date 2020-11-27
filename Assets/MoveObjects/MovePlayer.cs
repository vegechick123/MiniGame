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
        float h = Input.GetAxis("Horizontal");
        bool ver = Input.GetKeyDown("space");
        if (ver && isGround)
        {

            rb2d.AddForce(new Vector2(0, jumpForce));
            if(!Input .GetKeyDown ("right")||!Input .GetKeyDown ("left"))
            animator.SetTrigger("isJump");
        }
        /* if (h != 0)
         {

             rb2d.velocity = new Vector2(h * moveSpeed, 0);                   
             animator.SetTrigger("isRun"); 
             // currentPos = targetPos;
             //targetPos += new Vector2(1f, 0f);
             //restTimer = 0;
         }
         if (h != 0 && ver)
         {
             animator.SetTrigger("isIdle");
         }*/
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

            //设置自身缩放的值
            transform.localScale = new Vector2(1f, 1f);
            animator.SetTrigger("isRun");
        }
        //角色水平移动
        //按住A键，判断如果小于0，则向左开始移动
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);

            //如果new Vector2(-1f, 1f)  x值为负数，则图片进行反转显示
            transform.localScale = new Vector2(-1f, 1f);
            animator.SetTrigger("isRun");
        }
        else
        //角色水平移动
        //松开按键，判断如果等于0，则停止移动
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
    

    



 