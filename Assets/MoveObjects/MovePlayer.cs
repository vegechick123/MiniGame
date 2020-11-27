using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce = 5f;
    public GameObject  groundCheck;
    public float dValue;
    public float moveSpeed = 5f;


    private bool isGround;
    private Rigidbody2D rb2d;
    private Vector2 targetPos = new Vector2(-6, -0.6851993f);
    private Vector2 currentPos = new Vector2(-6, -0.6851993f);
    private Animator animator;
    private GameObject Player;


    //private float smoothing = 4;
    // private float restTime = 0.5f;
    //private float restTimer = 0;
    // private float jumpHoldForce = 1.9f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rb2d.velocity = new Vector2(1f, 1f);
        //rb2d.MovePosition(Vector2.Lerp(currentPos , targetPos, restTimer*smoothing));
        //isGround = Physics2D.OverlapCircle(CheckPoint.position, CheckRadius, map);
       // float h = (int)Input.GetAxis("Horizontal");
        //restTimer += Time.deltaTime;
        //Vector2 dir = new Vector2(h, 0);
        //bool hor=Input .GetKeyDown("right");
       // bool hol = Input.GetKeyDown("left");
       // bool ver = Input.GetKeyDown("space");
       /* if (h!=0)
        {
            rb2d.velocity =new Vector2(h,0)*force;
            animator.SetTrigger("isRun");
            // currentPos = targetPos;
            //targetPos += new Vector2(1f, 0f);
            //restTimer = 0;
        }
        animator.SetTrigger("isIdle");

        /*if (hol)
         {
            rb2d.MovePosition (transform.position+dir*0.2f);
             animator.SetTrigger("isRun");
             //  currentPos = targetPos;
             // targetPos += new Vector2(-1f, 0f);

             //restTimer = 0;
         }
         /* if (ver&&IsGround())
          {          
              rb2d.AddForce ( new Vector2(0, jumpForce));
              animator.SetTrigger("isJump");

          }*/
        playerMove();
        animator.SetTrigger("isIdle");

    }
    public void playerMove()
    {
        float h = Input.GetAxis("Horizontal");
        bool ver = Input.GetKeyDown("space");
        if (ver && isGround)
        {
            rb2d.AddForce(new Vector2(0, jumpForce) );
            animator.SetTrigger("isJump");
        }
        if (h != 0)
        {
            rb2d.AddForce(new Vector2(h, 0) * moveSpeed);
            animator.SetTrigger("isRun");
            // currentPos = targetPos;
            //targetPos += new Vector2(1f, 0f);
            //restTimer = 0;
        }
        if(h!=0&&ver)
        {
            animator.SetTrigger("isIdle");
        }
        
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            isGround = false;
        }
    }


}
 