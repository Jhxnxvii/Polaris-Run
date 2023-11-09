using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    // Variables for movement and jump parameters.
    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;

    // Enum to track the character's movement state.
    private enum MovementState { Idle, Walking, Jumping, Falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    // Code for allowing the player to jump using the space bar, and the veloctiy of the jump, so that the player is not jumping infinitly.  
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

      if (Input.GetButtonDown("Jump") && IsGrounded())
       {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
       }

        UpdateAnimationState();
    }

    // Determine the character's animation state based on movement and velocity.
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.Walking;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Walking;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        // Set the animation state using an integer.
        anim.SetInteger("state", (int)state);
    }

    // Check if the character is grounded by performing a boxcast.
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

