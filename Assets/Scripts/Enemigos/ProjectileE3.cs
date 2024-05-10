using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileE3 : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    [SerializeField] private AudioSource shieldReflect;
    public float moveSpeed;
    void Start()
    {

    }

    void Update()
    {
        Vector3 rightPosition = transform.position + Vector3.right * moveSpeed;

        Vector3 moveDirection = Vector3.right;
        this.transform.position += moveDirection * moveSpeed * Time.deltaTime;
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
                Destroy(gameObject, 1.1f);
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
