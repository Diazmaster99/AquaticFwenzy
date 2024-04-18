using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private AudioClip AudioClipMuerteBoss;
    [SerializeField] private AudioClip AudioClipMuerteJugador;

    public GameObject menuWin, serpientesIzquierda, serpientesDerecha;

    private float moveSpeed, moveSpeedAnterior;

    public static int vidaBoss = 10;

    [SerializeField] private Animator animacionBoss;

    private bool sonidoBoss = true;
    private bool muerto = false;
    private bool gritando = false;
    private ParticleSystem _myParticleSystem;

    public bool isInvincible = false;
    public float invincibilityDuration = 2f; // Duration of invincibility frames in seconds
    private float invincibilityTimer = 0f;

    // Variables for visual feedback
    private SpriteRenderer spriteRenderer;
    private Color normalColor;
    private Color invincibleColor = new Color(1f, 1f, 1f, 0.5f); // Example: Semi-transparent white

    public PlayerController jugador;

    // Start is called before the first frame update
    void Start()
    {
        muerto = false;
        sonidoBoss = true;
        vidaBoss = 10;
        moveSpeed = 5f;
        moveSpeedAnterior = 5f;
        _myParticleSystem = GetComponent<ParticleSystem>();
        InvokeRepeating(nameof(InitiateShotWaterBubble),5,5);
        InvokeRepeating("VelocidadRandom", 2, 2);
        InvokeRepeating("ActualizarMovespeedAnterior", 2, 2);
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {
        // Update invincibility timer
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
                // Reset sprite color to normal
                spriteRenderer.color = normalColor;
            }
        }


        if (vidaBoss > 0)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);
        }

        if (vidaBoss < 5)
        {
            gritando = true;
            serpientesIzquierda.SetActive(true);
            serpientesDerecha.SetActive(true);
            //amimacionBoss.setBool("SegundoAtaque",true);
            
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
                menuWin.SetActive(true);
            }
            muerto = true;

            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Muerte();
            //Ganar
        }
    }

    private void PararDeGritar()
    {
        gritando = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!muerto && !gritando)
        {
            if (collision.gameObject.tag == "Boundary")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moveSpeed *= -1;
            }
        }
        

        if (collision.gameObject.tag == "Player" && PlayerController.shieldActive==false)
        {
            //vidaBoss--;
            //SoundEffect.clip = AudioClipMuerteJugador;
            //SoundEffect.Play();
            //Destroy(collision.gameObject);
            //Time.timeScale = 0f;
            jugador.StartInvincibility();


        }
        //if (collision.gameObject.tag == "Player" && PlayerController.shieldActive == true)
        //{
        //    //vidaBoss--;        
        //}

        if (collision.gameObject.tag == "Projectile")
        {
            if (!isInvincible)
            {
                // Apply damage to player health or update player health
                // Example: health -= damageAmount;

                // Trigger invincibility frames
                vidaBoss--;
                //Debug.Log("EL jefe tiene "+vidaBoss+" de vida");
                StartInvincibility();
            }

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
            ////botonMenu.SetActive(false);
            ////botonGameOver.SetActive(true);
            //SoundEffect.clip = AudioClipMuerteJugador;
            //SoundEffect.Play();
            //PowerUps.gunPowerUpOn = false;
            //Time.timeScale = 0f;
            //Destroy(col.gameObject);
            jugador.StartInvincibility();
        }
    }

    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        // Apply visual feedback for invincibility
        FlashSprite();
    }

    private void FlashSprite()
    {
        // Flash the sprite on and off during invincibility
        StartCoroutine(FlashSpriteCoroutine());
    }

    private IEnumerator FlashSpriteCoroutine()
    {
        while (invincibilityTimer > 0)
        {
            // Toggle between normal and invincible color
            spriteRenderer.color = invincibleColor;
            yield return new WaitForSeconds(0.1f); // Adjust the duration of each flash
            spriteRenderer.color = normalColor;
            yield return new WaitForSeconds(0.1f); // Adjust the duration of each flash
        }
    }

    //public void Muerte()
    //{    
    //    Destroy(gameObject);      
    //}

    private void ShotWaterBubble()
    {

        ParticleSystem.EmissionModule emitter;
        if (!muerto && !gritando)
        {
            emitter = _myParticleSystem.emission;

            _myParticleSystem.Emit(20);
        }

        animacionBoss.SetBool("Disparar", false);

    }

    private void InitiateShotWaterBubble()
    {
        animacionBoss.SetBool("Disparar",true);
    }

    private void ActualizarMovespeedAnterior() 
    {
        moveSpeedAnterior = moveSpeed;
    }
    private void VelocidadRandom() 
    {
        moveSpeed = Random.Range(-5f, 5f);
          
        if ((moveSpeedAnterior >= 4 && moveSpeed >= 3) && (moveSpeed > -1 && moveSpeed < 1)) 
        {
            moveSpeed = Random.Range(-5f, 5f);
        }
        if ((moveSpeedAnterior <=-4 && moveSpeed <= -3) && (moveSpeed > -1 && moveSpeed < 1))
        {
            moveSpeed = Random.Range(-5f, 5f);
        }
        //Debug.Log(moveSpeed);
        //Debug.Log(moveSpeedAnterior);

    }
}
    

