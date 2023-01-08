using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animate;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 60f;

    float moveHorizontal;
    public bool isGrounded = true;
    private bool facingRight = true;

    int jumpCount = 0; 


    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        GettingInput();
        RunAnimation();
        Flipping();
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f));
        }
    }

    private void GettingInput()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount <2))
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            jumpCount++;
            animate.SetBool("sheJumping", true);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void RunAnimation()
    {
        animate.SetFloat("Speed", Mathf.Abs(moveHorizontal));
    }

    void Flipping()
    {
        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;

        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

    }

    

}


