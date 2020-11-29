using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    
    public AudioClip run;
    public AudioClip jump;

    public bool isGround;
    public BoxCollider2D colider;
    public GameObject prefabGroudedParticle;
    private bool touchGround;
    private Rigidbody2D rb2d;
    private Animator animator;
    private GameObject player;
    private AudioSource musicRun;
    private AudioSource musicJump;

    void Start()
    {
        musicRun = gameObject.AddComponent<AudioSource>();
        musicRun.playOnAwake = false;
        musicJump = gameObject.AddComponent<AudioSource>();
        musicJump.playOnAwake = false;
        animator = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        isGround = true;
        touchGround = true;
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
        //audio
        if ((Input.GetKeyDown("right") || Input.GetKeyDown("left")) && isGround)
        {
            musicRun.clip = run;
            musicRun.Play();
        }
        
            if (Input .GetKeyDown("space")&&isGround )
        {
            musicJump.clip = jump;
            musicJump.Play();
        }
       
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);       
            transform.localScale = new Vector2(1f, 1f);
            if (isGround)
            animator.SetBool("Walk",true);
            musicRun.loop = true;
        }        
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y); 
            transform.localScale = new Vector2(-1f, 1f);
            if(isGround)
            animator.SetBool("Walk",true);
            musicRun.loop = true;
        }
        else
        {
           
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            musicRun.Pause();
            //animator.SetTrigger("Jump");
            animator.SetBool("Walk", false);

        }
        animator.SetTrigger("Idle");
        

    }
    private void FixedUpdate()
    {
        RaycastHit2D[] result = new RaycastHit2D[5];
        int val = colider.Cast(Vector2.down, result,0.05f);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        //if(hit.collider!=null)
        //if(isGround&&val!=0)
        if (!isGround && val != 0)
        {
            animator.SetTrigger("Grounded");
            Instantiate(prefabGroudedParticle, transform.position - new Vector3(0, colider.size.y / 2, 0), prefabGroudedParticle.transform.rotation,null);
         
        }
        isGround = val != 0; 
    }
    
}
    

    



 