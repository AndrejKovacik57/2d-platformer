using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D playerBody;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    float horizontalInput;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSound;
    private enum MovementState { idle, run, jump, fall}

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //movement
        playerBody.velocity = new Vector2(horizontalInput * speed, playerBody.velocity.y);

        //jump
        if (Input.GetButtonDown("Jump") && groundCheck())
        {
            jumpSound.Play();
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }
            

        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        MovementState state;

        //running right
        if (horizontalInput > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        //running left
        else if (horizontalInput < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        //idle
        else
        {
            state = MovementState.idle;
        }

        //jumping
        if (playerBody.velocity.y > 0.1f)
        {

            state = MovementState.jump;
        }
        //falling
        else if (playerBody.velocity.y < -0.1f)
        {
            state = MovementState.fall;     
        }

        anim.SetInteger("state", (int)state);
    }

    private bool groundCheck()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
