using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    private float dirX = 0f;

    //setting up fields to be able to change values directly in unity interface
    [SerializeField] private float moveSpeed = 7f; 
    [SerializeField] private float jumpForce= 14f; 
    [SerializeField] private LayerMask jumpableGround;


    private enum MovementState { idle, walk, jump, fall  }


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

     
    }
    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) //checks if player is in the air or not before next jump is possible
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //Function for flipping animation according to player movement direction/position
    private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }

        else if (dirX < 0f)
        {

            state = MovementState.walk;
            sprite.flipX = false;
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {

            state = MovementState.jump;
        }

        else if (rb.velocity.y < -.1f)
        {

            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }  
}
