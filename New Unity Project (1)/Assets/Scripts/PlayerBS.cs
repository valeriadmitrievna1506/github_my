using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBS : MonoBehaviour
{
    public float xSpeed = 200f;
    private float horizontal;
    public Rigidbody2D rb;
    public bool isRight = true;
    public float player_health = 100f;
    public Slider slider;
    public float ySpeed = 600f;

    public Transform groundCheck;
    bool isGrounded;
    float groundRadius = 0.5f;
    public LayerMask whatIsGround;

    bool simulated = true;

    public AudioClip walking;
    public AudioSource source;
    public GameObject canvas;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        slider.value = player_health;
        print(player_health);
        horizontal = Input.GetAxis("Horizontal");
        flip();
        if (player_health > 0 && simulated)
        {
            rb.velocity = new Vector2(horizontal * xSpeed * Time.deltaTime, rb.velocity.y);
            if (Mathf.Abs(horizontal) > 0)
            {
                if (!source.isPlaying)
                {
                    source.clip = walking;
                    source.Play();
                }
            }
            else source.Stop();
        }
        if (!isGrounded) return;
    }


    void Update()
    {
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.AddForce(new Vector2(0, ySpeed));
        }
    }

    void flip()
    {
        if (((horizontal < 0) && isRight) || (((horizontal > 0) && !isRight)))
        {
            isRight = !isRight;
            float flipx = transform.localScale.x;
            transform.localScale = new Vector3(flipx *= -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            player_health -= 5f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "level end")
        {
            simulated = false;
            rb.velocity = new Vector2(0.8f * xSpeed * Time.deltaTime, rb.velocity.y);
            StartCoroutine(canvas.GetComponent<CrossFade>().loadNextLevel());
        }
    }
}
