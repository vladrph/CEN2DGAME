using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Collider2D standingCollider;
    [SerializeField] Transform overheadCheckCollider;

    const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    [SerializeField] float jumpPower = 350;
    float horizontalValue;
    [SerializeField] public float speed = 3;
    [SerializeField] int totalJumps;
    int availableJumps;
    float crouchSpeedModifier = 0.5f;

    bool facingRight = true;
    [SerializeField] bool isGrounded;
    bool crouchPressed;
    bool multipleJump;



    void Awake()
    {
        availableJumps = totalJumps;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            Jump();

        if (Input.GetButtonDown("Crouch"))
        {
            crouchPressed = true;
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouchPressed = false;
        }
    }


    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, crouchPressed);
    }

    void Jump()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;

            rb.AddForce(new Vector2(0f, jumpPower));
            rb.velocity = Vector2.up * jumpPower;
        }

        else
        {
            if (multipleJump && availableJumps > 0)
            {
                availableJumps--;

                rb.AddForce(new Vector2(0f, jumpPower));
                rb.velocity = Vector2.up * jumpPower;
            }
        }
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        //Check if GroundCheckObject is colliding with other 2D colliders
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
                availableJumps = totalJumps;
                multipleJump = false;
        }
    }

    void Move(float dir, bool crouchFlag)
    {
        if(!crouchFlag)
        {
            if(Physics2D.OverlapCircle(overheadCheckCollider.position, overheadCheckRadius, groundLayer))
                crouchFlag = true;
        }
        standingCollider.enabled = !crouchFlag;


      if (isGrounded)
     {
        standingCollider.enabled = !crouchFlag;
    }

        float xVal = dir * speed * Time.deltaTime * 100;

    if (crouchFlag)
        xVal *= crouchSpeedModifier;

        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

  
        //if looking right and clicked left (flip to the left)
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
    }
  }
