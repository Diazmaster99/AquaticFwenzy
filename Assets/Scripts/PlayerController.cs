using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput, vInput;
    public bool fastShoot = false;
    public static bool shieldActive = false;
    public static int puntos;
    public bool grenadeLauncher = false;
    public GameObject shieldPrefab;
    public PowerUps powerUps;
    public PowerUpTimer powerUpTimer;
    [SerializeField] private GameObject botonGameOver;
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject MenuWin;
    [SerializeField] private AudioSource shieldDown;
    [SerializeField] private GameObject efecto;
    public int  vidas;
    public GameObject[] imagenVidas;
    [SerializeField] private TextMeshProUGUI puntosDisplay;

    public TextMeshProUGUI txtPowerUp1;
    public TextMeshProUGUI txtPowerUp2;
    public TextMeshProUGUI txtPowerUp3;

    public GameObject floatingTextPrefab;
    public GameObject canvas;

    public GameManager gameManager;

    //public Vector3 minPosition;
    //public Vector3 maxPosition;

    public Collider2D boundaryCollider;



    //public bool isInvincible = false;
    //public float invincibilityDuration = 2f; // Duration of invincibility frames in seconds
    //private float invincibilityTimer = 0f;

    //// Variables for visual feedback
    //private SpriteRenderer spriteRenderer;
    //private Color normalColor;
    //private Color invincibleColor = new Color(1f, 1f, 1f, 0.5f); // Example: Semi-transparent white


    //[SerializeField] private AudioSource killPlayerSoundEffect;

    //public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        PowerUps.gunPowerUpOn = false;
        vidas = 2;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //normalColor = spriteRenderer.color;
        //vidas = imagenVidas;

        //Vector3 clampedPosition = transform.position;
        //clampedPosition.x = Mathf.Clamp(clampedPosition.x, minPosition.x, maxPosition.x);
        //clampedPosition.y = Mathf.Clamp(clampedPosition.y, minPosition.y, maxPosition.y);

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * vInput * moveSpeed * Time.deltaTime);
        
        if (puntosDisplay != null)
        {
            puntosDisplay.SetText("Puntos: " + puntos);
        }

         //Ensure the object stays within the boundary collider
        if (!boundaryCollider.bounds.Contains(transform.position))
        {
            // If the object moves outside the boundary, clamp its position back inside
            transform.position = boundaryCollider.ClosestPoint(transform.position);
            //Debug.Log("Fuera");
        }

        // Ensure the object stays within the boundary collider
        if (boundaryCollider.bounds.Contains(transform.position))
        {
            // If the object moves outside the boundary, clamp its position back inside
            transform.position = boundaryCollider.ClosestPoint(transform.position);
            //Debug.Log("Dentro");
        }
        

        //puntosDisplay.ForceMeshUpdate(true);
    }


    public void perderVida()
    {
        switch (vidas)
        {
            case 0:
                imagenVidas[0].SetActive(false);
                botonPausa.SetActive(false);
                //killPlayerSoundEffect.Play();
                botonGameOver.SetActive(true);
                Time.timeScale = 0f;
                Destroy(gameObject);
                break;
            case 1:
                imagenVidas[1].SetActive(false);
                vidas--;
                break;
            case 2:
                imagenVidas[2].SetActive(false);
                vidas--;
                break;
        }
    }

    public void SumarPuntos()
    {
        puntos += 1000;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
 
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "Boss") && shieldActive==false )
        {
            perderVida();
            Destroy(col.gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {

        }
    }

    private void OnParticleCollision(GameObject col)
    {
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "Boss") && shieldActive == false)
        {
            /*killPlayerSoundEffect.Play();
            botonPausa.SetActive(false);
            botonGameOver.SetActive(true);
            PowerUps.gunPowerUpOn = false;          
            Time.timeScale = 0f;
            Destroy(this.gameObject);
            //jugador.drag = 20;
            */
           perderVida();
           Destroy(col.gameObject);

        }
    }
    public void CanFastShoot()
    {
        //fastShoot = true;
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOn();
        //txtPowerUp1.gameObject.SetActive(true);

        GameObject floatingText = Instantiate(floatingTextPrefab, this.transform.position, Quaternion.identity);
        floatingText.transform.SetParent(canvas.transform, false);
        floatingText.GetComponent<TextMeshProUGUI>().text = "¡A por todas!";
        TextoFluido textoFluido = floatingText.AddComponent<TextoFluido>();

        Destroy(floatingText, 2f);

        StartCoroutine (FastShootDownRoutine());
    }

    public void ShieldPowerUpOn() 
    {
        shieldActive = true;
        shieldPrefab.SetActive(true);

        GameObject floatingText = Instantiate(floatingTextPrefab, this.transform.position, Quaternion.identity);
        floatingText.transform.SetParent(canvas.transform, false);
        floatingText.GetComponent<TextMeshProUGUI>().text = "¡Protegete!";
        TextoFluido textoFluido = floatingText.AddComponent<TextoFluido>();

        Destroy(floatingText, 2f);

        StartCoroutine (ShieldDownRoutine());
    }

    public void CanGrenadeLauncher()
    {
        grenadeLauncher = true; 
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.GrenadeLauncherOn();

        GameObject floatingText = Instantiate(floatingTextPrefab, this.transform.position, Quaternion.identity);
        floatingText.transform.SetParent(canvas.transform, false);
        floatingText.GetComponent<TextMeshProUGUI>().text = "¡A saco paco!";
        TextoFluido textoFluido = floatingText.AddComponent<TextoFluido>();

        Destroy(floatingText, 2f);

        StartCoroutine(GrenadeLauncherDownRoutine());
    }
    public IEnumerator FastShootDownRoutine() 
    {
        PowerUpTimer.tiempoMax = 3;
        yield return new WaitForSeconds(3f);
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOff();
        txtPowerUp1.gameObject.SetActive(false);
    }
    public IEnumerator ShieldDownRoutine() 
    {
        PowerUpTimer.tiempoMax = 3;
        yield return new WaitForSeconds(3f);
        shieldDown.Play();
        shieldPrefab.SetActive(false);
        shieldActive = false;
        txtPowerUp2.gameObject.SetActive(false);

        
    }
    public IEnumerator GrenadeLauncherDownRoutine()
    {
        PowerUpTimer.tiempoMax = 6;
        yield return new WaitForSeconds(6f);     
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOff();
        grenadeLauncher = false;
        txtPowerUp3.gameObject.SetActive(false);

        
    }
}
