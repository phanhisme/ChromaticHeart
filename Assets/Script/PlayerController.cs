using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask platform;
    [SerializeField] Transform groundCheck;

    private float horizontal;
    private float runningSpeed = 8f;
    private float jumpForce = 8f;

    public Animator anim;
    private BoxCollider2D box2d;

    bool facingRight = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        box2d = transform.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Horizontal"))
        {
            anim.SetTrigger("isRunning");
        }
        else
            anim.SetTrigger("isIdle");
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runningSpeed, rb.velocity.y);
    }

    //void Movement()
    //{
    //    Vector3 playerPos = this.transform.position;
        
    //    {
    //        playerPos.x = playerPos.x + runningSpeed;
    //        this.transform.position = playerPos;

    //        anim.SetTrigger("isRunning");

    //        if (facingRight == false)
    //        {
    //            Flip();
    //        }
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        playerPos.x = playerPos.x - runningSpeed;
    //        this.transform.position = playerPos;

            

    //        if (facingRight == true)
    //        {
    //            Flip();
    //        }
    //    }
    //}

    void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            //set the facingRight variable to the opposite of what it was
            facingRight = !facingRight;

            //store the scale of the player in a variable
            Vector3 playerScale = transform.localScale;

            //reverse the direction of the player
            playerScale.x *= -1;

            //set the player's scale to the new value
            transform.localScale = playerScale;
        }
    }

    void Jump() //not working properly + animation is not correct
    {
        anim.SetTrigger("isJumping");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    bool isGrounded()
    {
        //float h = 0.2f;
        //RaycastHit2D raycastHit = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, box2d.bounds.extents.y + h, platform);
        //return raycastHit.collider != null;

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, platform);
    }
}
