using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private AudioSource killEnemySoundEffect;
    public AudioSource killKrillSoundEffect;
    public float moveSpeed;
    Animator muerte;
    [SerializeField] public PlayerController player;
    void Start()
    {
        muerte = null;
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
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                killEnemySoundEffect = collision.GetComponent<AudioSource>();

                Debug.Log("Enemigo colisionado"+ collision.name);

                killEnemySoundEffect.Play();
               
                
                muerte = collision.gameObject.GetComponent<Animator>();
                if (muerte != null)
                {
                    muerte.SetBool("Muerte", true);
                }
                //Destroy(collision.gameObject); 
                Destroy(gameObject,1.1f);
                
                player.SumarPuntos();
            }

            if (collision.gameObject.tag == "Boss")
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //muerte = collision.gameObject.GetComponent<Animator>();

                Destroy(gameObject, 1.1f);
            }
          
          
        }   

        if (collision.gameObject.tag == "ProjectileBoundary")
        {
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject col)
    {
        player.SumarPuntosKrill();
        killKrillSoundEffect.Play();

        Destroy(this.gameObject,0.5f);

    }

}
