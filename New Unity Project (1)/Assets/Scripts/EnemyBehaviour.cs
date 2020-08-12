using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 100f;
    public float requiredDistance = 10f;
    float enemy_health = 100f;
    public GameObject player;
    float direction;
    public bool isRight = false;
    public Color normalColor;

    void Awake()
    {
        normalColor = GetComponent<SpriteRenderer>().color;
    }

    void FixedUpdate()
    {
        Death(); // проверка на смерть
        PlayerDirection(); // в каком направлении стоит игрок
        flip(); // повернуть врага при необходимости

        if ((PlayerDistance() < requiredDistance) && (PlayerDistance() > 1f)) // условие движения
        {
            EnemyMove();
        }
    }

    float PlayerDistance()
    {
        return (Mathf.Abs(transform.position.x - player.transform.position.x));
    }

    void PlayerDirection()
    {
        if (player.transform.position.x < transform.position.x) direction = -1f;
        else direction = 1f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemy_health -= Random.Range(10, 30);
            Destroy(collision.gameObject);
            StartCoroutine(Damaging());
        }
    }

    void EnemyMove()
    {
        rb.velocity = new Vector2(speed * direction * Time.deltaTime, rb.velocity.y);
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

    void Death()
    {
        if (enemy_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Damaging()
    {
        // смена цвета при нанесении урона
        gameObject.GetComponent<SpriteRenderer>().color = new Color(25, 181, 0, 255);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = normalColor;
    }

}
