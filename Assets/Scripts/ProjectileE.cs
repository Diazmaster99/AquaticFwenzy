using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileE : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    [SerializeField] private AudioSource shieldReflect;
    public float moveSpeed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!PlayerController.shieldActive)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                killPlayerSoundEffect.Play();
                //Destroy(collision.gameObject);
                Destroy(gameObject, 0.5f);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                shieldReflect.Play();
                Destroy(gameObject, 0.5f);
            }
            
        }

        if (collision.gameObject.tag == "Shield")
        {
            shieldReflect.Play();
            Destroy(gameObject, 0.5f);
        }

        if (collision.gameObject.tag == "DestroyBoundary")
        {
            Destroy(gameObject);
        }
    }
    
}
