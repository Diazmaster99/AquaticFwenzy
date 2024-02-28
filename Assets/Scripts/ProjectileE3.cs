using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileE3 : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    public float moveSpeed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            killPlayerSoundEffect.Play();
            //Destroy(collision.gameObject);
            Destroy(gameObject, 1.1f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "DestroyBoundary")
        {
            Destroy(gameObject);
        }
    }
    
}
