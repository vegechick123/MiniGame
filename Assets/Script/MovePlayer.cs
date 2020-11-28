using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;


    public bool isGround;
    public BoxCollider2D colider;
    private Rigidbody2D rb2d;
    private Animator animator;
    private GameObject Player;


    void Start()
    {
        animator = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
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

            rb2d.velocity=new Vector2(0,jumpForce);
            
            animator.SetTrigger("Jump");
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
    private void FixedUpdate()
    {
        RaycastHit2D[] result = new RaycastHit2D[5];
        int val = colider.Raycast(Vector2.down, result, colider.size.y/2+0.05f);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        //if(hit.collider!=null)
        if(isGround==false&&val!=0)
        {
            animator.SetTrigger("Grounded");
        }
        isGround = val != 0;
    }
}
    

    



 