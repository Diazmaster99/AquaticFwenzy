using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput, vInput;
    public bool fastShoot = false;
    public static bool shieldActive = false;
    public bool grenadeLauncher = false;
    public GameObject shieldPrefab;
    public PowerUps powerUps;
    [SerializeField] private GameObject botonGameOver;
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject MenuWin;
    [SerializeField] private AudioSource shieldDown;
    [SerializeField] private GameObject efecto;
    [SerializeField] public static int puntos, vidas;
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



    public bool isInvincible = false;
    public float invincibilityDuration = 2f; // Duration of invincibility frames in seconds
    private float invincibilityTimer = 0f;

    // Variables for visual feedback
    private SpriteRenderer spriteRenderer;
    private Color normalColor;
    private Color invincibleColor = new Color(1f, 1f, 1f, 0.5f); // Example: Semi-transparent white


    //[SerializeField] private AudioSource killPlayerSoundEffect;

    //public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        PowerUps.gunPowerUpOn = false;
        vidas = 2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = spriteRenderer.color;

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

        /* Ensure the object stays within the boundary collider
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
            //transform.position = boundaryCollider.ClosestPoint(transform.position);
            //Debug.Log("Dentro");
        }
        */

        //puntosDisplay.ForceMeshUpdate(true);
    }


    public void Morir()
    {
        switch (vidas)
        {
            case 0:                            
                    //botonPausa.SetActive(false);
                    botonGameOver.SetActive(true);
                    Time.timeScale = 0f;
                    Destroy(gameObject);
                
                break;
            case 1:
            case 2:
                    //botonPausa.SetActive(true);
                    vidas--;
                
                break;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PerderVida();
        }
    }*/

    public void SumarPuntos()
    {
        puntos += 1000;
        /*if (puntos == 1000) {    
            puntos += 1000;
        }*/
    }

    //private void OnTrigerEnter2D(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //puntuaje.SumarPuntos(cantidadPuntos);
    //        Instantiate(efecto, transform.position, Quaternion.identity);
    //        Destroy(gameObject);
    //    }
    //}


    void OnTriggerEnter2D(Collider2D col)
    {
 
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "Boss") && shieldActive==false )
        {
            /*botonPausa.SetActive(false);
            botonGameOver.SetActive(true);
            PowerUps.gunPowerUpOn = false;
            Time.timeScale = 0f;
            Destroy(this.gameObject);
            jugador.drag = 20; */
            Morir();
            
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
           Morir();

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
        floatingText.GetComponent<TextMeshProUGUI>().text = "Fwenzy!";
        Destroy(floatingText, 2f);

        StartCoroutine (FastShootDownRoutine());
    }

    public void ShieldPowerUpOn() 
    {
        shieldActive = true;
        shieldPrefab.SetActive(true);
        //txtPowerUp2.gameObject.SetActive(true);

        GameObject floatingText = Instantiate(floatingTextPrefab, this.transform.position, Quaternion.identity);
        floatingText.transform.SetParent(canvas.transform, false);
        floatingText.GetComponent<TextMeshProUGUI>().text = "Escudo!";
        Destroy(floatingText, 2f);

        StartCoroutine (ShieldDownRoutine());
    }

    public void CanGrenadeLauncher()
    {
        grenadeLauncher = true; 
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.GrenadeLauncherOn();
        //txtPowerUp3.gameObject.SetActive(true);

        GameObject floatingText = Instantiate(floatingTextPrefab, this.transform.position, Quaternion.identity);
        floatingText.transform.SetParent(canvas.transform, false);
        floatingText.GetComponent<TextMeshProUGUI>().text = "Lanzagranadas!";
        Destroy(floatingText, 2f);

        StartCoroutine(GrenadeLauncherDownRoutine());
    }
    public IEnumerator FastShootDownRoutine() 
    {
        yield return new WaitForSeconds(3f);
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOff();
        txtPowerUp1.gameObject.SetActive(false);
        //fastShoot = false;
    }
    public IEnumerator ShieldDownRoutine() 
    {
        yield return new WaitForSeconds(3f);
        shieldDown.Play();
        shieldPrefab.SetActive(false);
        shieldActive = false;
        txtPowerUp2.gameObject.SetActive(false);

        
    }
    public IEnumerator GrenadeLauncherDownRoutine()
    {
        yield return new WaitForSeconds(6f);     
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOff();
        grenadeLauncher = false;
        txtPowerUp3.gameObject.SetActive(false);

        
    }
}
