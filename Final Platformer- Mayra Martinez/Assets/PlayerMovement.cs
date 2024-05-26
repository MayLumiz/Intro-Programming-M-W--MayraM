using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("PlayerMovement")]
    private bool isFacingRight = false;
    public float moveSpeed = 5f;
    float horizontalMovement;
    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2;
    int jumpsRemaining;
    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.49f, 0.03f);
    public LayerMask groundLayer;
    bool isGrounded;
    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;
    [Header("WallCheck")]
    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.49f, 0.03f);
    public LayerMask wallLayer;
    [Header("WallMovement")]
    public float wallSlideSpeed = 2;
    bool isWallSliding;
    bool isWallJumping;
    float wallJumpDirection;
    float wallJumpTime = 0.5f;
    float wallJumpTimer;
    public Vector2 wallJumpPower = new Vector2(5f, 10f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        ProcessGravity();
        ProcessWallSlide();
        ProcessWallJump();

        if (!isWallJumping)
        {
          rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
          Flip();
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
        if (context.performed)
        {
            //hold down jump for big jump
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpsRemaining--;
        }
        else if (context.canceled)
        {
            //little jump 
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            jumpsRemaining--;
        }
        }
        //walljumping
        if(context.performed && wallJumpTimer > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y); //Jump away from the wall 
            wallJumpTimer= 0f;

            //force flip
            if(transform.localScale.x != wallJumpDirection)
            {
              isFacingRight = !isFacingRight;
              Vector3 ls = transform.localScale;
              ls.x *= -1f;
              transform.localScale = ls;
            }

            Invoke(nameof(CancelWallJump), wallJumpTime + 0.1f); // wall jump = 0.05f -- jump again = 0.6f
        }
    }
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer)) // checks if set box overlaps w ground
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
        }
    }
    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position,wallCheckSize, 0, wallLayer);
    }
    private void ProcessGravity()
    {
        //falling gravity
         if(rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; //fall faster 
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed)); // max fall speed
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    private void ProcessWallSlide()
    {
        if (!isGrounded & WallCheck() & horizontalMovement != 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, - wallSlideSpeed)); // caps fall rate
        }
        else 
        {
            isWallSliding = false;
        }
    }
    private void ProcessWallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpTimer = wallJumpTime;

            CancelInvoke(nameof(CancelWallJump));
        }
        else if (wallJumpTimer > 0f)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }
    private void CancelWallJump()
    {
        isWallJumping = false;
    }
    private void Flip()
    {
        if(isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(wallCheckPos.position, wallCheckSize);
    }
}