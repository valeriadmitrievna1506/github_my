using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed = 100f;
    public float requiredDistance = 10f;
    float health;
    public Transform player;
    float direction = 1f;
    public bool isRight = false;

    void Start()
    {
        health = 100f;
    }

    void FixedUpdate()
    {
        anim.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
        PlayerDirection();
        flip();
        if ((PlayerDistance() < requiredDistance) && (PlayerDistance() > 1.5f))
        {
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
        }
        StartCoroutine(DamagingByPlayer());
        StartCoroutine(Death());
    }

    float PlayerDistance()
    {
        return (Mathf.Abs(transform.position.x - player.position.x));
    }

    void PlayerDirection()
    {
        if (player.position.x < transform.position.x) direction = -1f;
        else direction = 1f;
    }

    IEnumerator DamagingByPlayer()
    {
        if ((PlayerDistance() < 5f) && PlayerBehaviour.shooting)
        {
            health -= Random.Range(5, 30);
        }
        yield return new WaitForSeconds(0.2f);
    }

    void flip()
    {
        if (((direction == -1) && isRight) || (((direction == 1) && !isRight)))
        {
            isRight = !isRight;
            float flipx = transform.localScale.x;
            transform.localScale = new Vector3(flipx *= -1, transform.localScale.y, transform.localScale.z);
        }
    }

    IEnumerator Death()
    {
        if (health < 0)
        {
            anim.SetBool("Dead", true);
            yield return new WaitForSeconds(1.6f);
            Destroy(gameObject);
        }
        
    }
}
