using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator anim;
    public float speed = 200f;
    private float horizontal;
    public Rigidbody2D rb;
    private bool isRight = true;
    public float health = 100f;
    public static bool shooting;
    public Slider slider;
    bool alive;
    public GameObject forPause;
    int damagingTime;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        slider.value = health;
        if (health > 0)
        {
            alive = true;
            horizontal = Input.GetAxis("Horizontal");
            anim.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
            flip();
             rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);

            if (Input.GetKey(KeyCode.X) && shooting == false)
            {
                StartCoroutine(Shoot());
            }

            if (Input.GetKeyDown(KeyCode.S)) health -= 10;
        }
        else
        {
            StartCoroutine(Death());
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

    IEnumerator Shoot()
    {
        shooting = true;
        anim.SetBool("shooting", shooting);
        yield return new WaitForSeconds(0.2f);
        shooting = false;
        anim.SetBool("shooting", shooting);
    }

    private void OnTriggerStay2D (Collider2D someone)
    {
        if (someone.gameObject.tag == "enemy")
        {
            damagingTime += 1;
            if (damagingTime % 40 == 0) //Debug.Log(damagingTime);
                StartCoroutine(DamageByEnemy());
        }
    }

    IEnumerator DamageByEnemy()
    {
        health -= 1.5f;
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Death ()
    {
        alive = false;
        anim.SetBool("Dead", !alive);
        yield return new WaitForSeconds(1.6f);
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
