using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private AudioSource killEnemySoundEffect;
    void Start()
    {
       
    }

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Enemy") 
         {      
             killEnemySoundEffect.Play();
             Destroy(collision.gameObject);
             Destroy(gameObject);
         }

         if (collision.gameObject.tag == "Boundary")
         {
             killEnemySoundEffect.Play();
             Destroy(gameObject);
         }
         
        //killEnemySoundEffect.Play();
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            killEnemySoundEffect.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boundary")
        {

            Destroy(gameObject);
        }
    }*/
}
