using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosion;
    [SerializeField] private AudioSource grenadeSoundEffect;
    public float moveSpeed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        StartCoroutine(Explode(2));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "Enemies")
        {

            if (collision.gameObject.tag == "Enemy")
            {     
                StartCoroutine(Explode(0));
                grenadeSoundEffect.Play();
            }
            
        }

        if (collision.gameObject.tag == "ProjectileBoundary")
        {
            Destroy(gameObject);
        }


    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(explosion, transform.position, Quaternion.identity);    
        Destroy(gameObject);
    }
}
