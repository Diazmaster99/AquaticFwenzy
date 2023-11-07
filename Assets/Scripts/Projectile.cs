using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
        void Start()
    {
       
    }

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "Enemies")
        {
           
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Boundary")
         {
             Destroy(gameObject);
         }
         
        
    }
}
