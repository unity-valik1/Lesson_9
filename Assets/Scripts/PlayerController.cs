using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float tolerance = 0.1f;
    public float speed = 1;
    public float jumpForce = 5;

    public Vector3 startPos;

    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D boxCollider2;

    bool isDead;
    public float speedFly = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        boxCollider2 = GetComponent<BoxCollider2D>();
        startPos = transform.position;
    }

    void Update()
    {
        if (!isDead)
        {
            float movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
            // https://docs.unity3d.com/ScriptReference/Rigidbody2D.MovePosition.html

            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            sr.flipX = movement < 0 ? true : false;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, speedFly * Time.deltaTime);
            /*if(Vector3.Distance(transform.position, startPos) <= tolerance)
            {

            }*/
            if (transform.position.x <= -3.8f)
            {
                boxCollider2.enabled = true;
                rb.gravityScale = 1;
                isDead = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            rb.gravityScale = 0;
            boxCollider2.enabled= false;
            isDead = true;
            //transform.position = startPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColUp")
        {
            rb.AddForce(new Vector2(0, jumpForce) / 2, ForceMode2D.Impulse);
        }
    }
}
