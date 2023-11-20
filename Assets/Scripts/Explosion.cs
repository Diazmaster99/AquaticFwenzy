using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    [SerializeField] private AudioSource killEnemySoundEffect;
    public float radius = 5;

    void Start()
    {

    }

    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in enemyHit)
        {
            OnTriggerEnter2D(col);
        }
        StartCoroutine(Explode(1));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "Enemies")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                killEnemySoundEffect.Play();
                StartCoroutine(Explode(0));
            }
        }

        if (collision.gameObject.tag == "ProjectileBoundary")
        {
            Destroy(gameObject);
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
