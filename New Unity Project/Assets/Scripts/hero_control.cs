using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_control : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    private float moveX;
    private bool isRight = true;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    private bool isGrounded;
    public float groundRadius = 0.4f;

    //public GameObject resp, cam;
    //int N = 5;
    //public GameObject[] lives = new GameObject[5];
    //public GameObject dead_screen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("grounded", isGrounded);
        animator.SetFloat("ySpeed", rb.velocity.y);
        moveX = Input.GetAxis("Horizontal");

        animator.SetFloat("xSpeed", Mathf.Abs(moveX));
        flip();
        rb.velocity = new Vector2(moveX * 8, rb.velocity.y);

    }

    void Update()
    {

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            animator.SetBool("grounded", false);
            rb.AddForce(new Vector2(0, 1000));
        }
    }

    void flip()
    {
        if ((isRight && moveX < 0) || (!isRight && moveX > 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            isRight = !isRight;
        }
    }




}