using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private AudioClip AudioClipMuerteBoss;
    [SerializeField] private AudioClip AudioClipMuerteJugador;
    public float moveSpeed;
    public static int vidaBoss = 10;
    [SerializeField] private Animator animacionBoss;
    private bool sonidoBoss = true;
    private bool muerto = false;
    // Start is called before the first frame update
    void Start()
    {
        muerto = false;
        sonidoBoss = true;
        vidaBoss = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaBoss >0)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);
        }

        if (vidaBoss <= 0)
        {
            if (sonidoBoss)
            {
                SoundEffect.clip = AudioClipMuerteBoss;
                SoundEffect.Play();
                sonidoBoss = false;
            }
            transform.Translate(Time.deltaTime * Vector2.up);

            if (animacionBoss != null)
            {
                animacionBoss.SetBool("Muerte", true);
            }

            //Muerte();
            //Ganar
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!muerto)
        {
            if (collision.gameObject.tag == "Boundary")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moveSpeed *= -1;
            }
        }
        

        if (collision.gameObject.tag == "Player" && PlayerController.shieldActive==false)
        {
            vidaBoss--;
            SoundEffect.clip = AudioClipMuerteJugador;
            SoundEffect.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player" && PlayerController.shieldActive == true)
        {
            vidaBoss--;        
        }

        if (collision.gameObject.tag == "Projectile")
        {
            vidaBoss--;
        }

    }
    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && PlayerController.shieldActive == false)
        {
            // botonMenu.SetActive(false);
            // botonGameOver.SetActive(true);
            SoundEffect.clip = AudioClipMuerteJugador;
            SoundEffect.Play();
            PowerUps.gunPowerUpOn = false;
            Time.timeScale = 0f;
            Destroy(col.gameObject);
        }
    }

    public void Muerte()
    {    
        Destroy(gameObject);      
    }
}
    

