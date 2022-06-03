using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Update : MonoBehaviour
{

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    private float moveY;

    private bool isDashing = false;
    private float cooldownTimer = 0.0f;
    private float cooldown = 1.0f;
    public float dashTime = 0.3f;
    private float dashTimer = 0.0f;
    public float dashSpeed = 9.0f;
    private float speedNow = 0.0f;

    [Tooltip("Only change this if your character is having problems jumping when they shouldn't or not jumping at all.")]
    public float distToGround = 1.0f;
    private bool inControl = true;

    [Tooltip("Everything you jump on should be put in a ground layer. Without this, your player probably* is able to jump infinitely")]
    public LayerMask GroundLayer;





    // Update is called once per frame
    void Update()
    {
        if (inControl && tag.Equals("Player"))
        {
            PlayerMove();
        }

    }

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        //ANIMATIONS
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
        }

        if (!isDashing)
        {
            speedNow = playerSpeed;
            //PLAYER DIRECTION
            if (moveX < 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveX > 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (cooldownTimer > 0.0f)
            {
                cooldownTimer -= Time.deltaTime;
            }

            if (cooldownTimer <= 0.0f && gameObject.name.Equals("Spirit Character") && Input.GetButtonDown("Power1"))
            {
                cooldownTimer = cooldown;
                isDashing = true;
                dashTimer = dashTime;
            }
        }
        if (isDashing)
        {
            float dir = (GetComponent<SpriteRenderer>().flipX) ? -1.0f : 1.0f;
            if (dashTimer > 0.0f)
            {
                speedNow = dashSpeed * dir;
                moveX = 1.0f;
                Debug.Log(playerSpeed);
            }

            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0.0f)
            {
                isDashing = false;
            }
        }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speedNow, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);

    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround, GroundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;

    }

    public void SetControl(bool b)
    {
        inControl = b;
    }
}
