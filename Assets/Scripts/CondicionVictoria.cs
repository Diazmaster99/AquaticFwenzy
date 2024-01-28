using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionVictoria : MonoBehaviour
{
    public GameObject menuwin;
    public float moveSpeed;
    public float decelerationRate = 1;
    private Rigidbody2D rb;
    private bool final = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (final)
        {
            Slow();
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ProjectileBoundary")
        {
            final = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            
            menuwin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void Slow()
    {

        moveSpeed = moveSpeed - 0.01f;

        if (moveSpeed <= 0) 
        {
            moveSpeed = 0;
        }

        //rb.gravityScale -= decelerationRate * Time.deltaTime;

        //if (rb.gravityScale<=0)
        //{
        //    moveSpeed = 0f;
        //    rb.gravityScale = 0f;
        //}

        //// Slow down the object gradually
        //if (rb.velocity.magnitude > 0.1f)
        //{
        //    rb.velocity -= rb.velocity.normalized * decelerationRate * Time.deltaTime;
        //}
        //else
        //{
        //    // Stop the object completely when its speed is very low
        //    rb.velocity = Vector2.zero;
        //}

        

    }



}
