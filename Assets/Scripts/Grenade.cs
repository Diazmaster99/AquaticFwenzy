using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private AudioSource killEnemySoundEffect;
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
                gameObject.GetComponent<Renderer>().enabled = false;
                killEnemySoundEffect.Play();
                Destroy(collision.gameObject);
                Destroy(gameObject, 1.1f);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (collision.gameObject.tag == "ProjectileBoundary")
        {
            Destroy(gameObject);
        }


    }
}
