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
    [SerializeField] private GameObject botonGameOver;
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject MenuWin;
    [SerializeField] private AudioSource shieldDown, killPlayerSoundEffect;
    [SerializeField] private GameObject efecto;
    public int  vidas;
    public GameObject[] imagenVidas = new GameObject[3];
    [SerializeField] private TextMeshProUGUI puntosDisplay;

    public TextMeshProUGUI txtPowerUp1;
    public TextMeshProUGUI txtPowerUp2;
    public TextMeshProUGUI txtPowerUp3;

    public GameObject floatingTextPrefab;
    public GameObject canvas;

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

    public int textSizeIncreaseAmount = 50;
    public int defaultFontSize = 36;
    public float textSizeResetDelay = 0.5f;
    public float smoothTime = 0.2f; // Smoothing time for size transition
    private int targetFontSize;
    private Coroutine sizeTransitionCoroutine;


    //private Color startColor = new Color(0, 1, 0.816f); // #00FFD0
    //private Color endColor = new Color(0.851f, 0.745f, 0.18f, 1.0f); // #D9BE2E
    //public float speed = 5f; // Speed of color change


    //[SerializeField] private AudioSource killPlayerSoundEffect;

    //public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        PowerUps.gunPowerUpOn = false;
        vidas = 2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * vInput * moveSpeed * Time.deltaTime);

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
                if (!isInvincible)
                {
                    imagenVidas[0].SetActive(false);
                    botonPausa.SetActive(false);
                    killPlayerSoundEffect.Play();
                    botonGameOver.SetActive(true);
                    Time.timeScale = 0f;
                    //Destroy(gameObject);
                }
                    
                break;
            case 1:
                if (!isInvincible)
                {
                    imagenVidas[1].SetActive(false);
                    vidas--;
                }
                
                break;
            case 2:
                if (!isInvincible)
                {
                    imagenVidas[2].SetActive(false);
                    vidas--;
                }
                break;
        }
    }

    private void StartInvincibility()
    {
        perderVida();
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

    void IncreaseTextSize()
    {
        // Increase text size
        puntosDisplay.fontSize = (int)textSizeIncreaseAmount;
        //cambiarTextoPuntuaje();
        ResetTextSizeDelayed();
    }

    void ResetTextSizeDelayed()
    {
        // Reset text size after a delay
        Invoke("ResetTextSize", textSizeResetDelay);
    }

    void ResetTextSize()
    {
        // Reset text size to default
        if (sizeTransitionCoroutine != null)
        {
            StopCoroutine(sizeTransitionCoroutine);
        }

        sizeTransitionCoroutine = StartCoroutine(SmoothFontSizeTransition());

        puntosDisplay.fontSize = defaultFontSize;
    }

    IEnumerator SmoothFontSizeTransition()
    {
        targetFontSize = 36;
        float currentFontSize = puntosDisplay.fontSize;
        float t = 0;

        while (t < smoothTime)
        {
            t += Time.deltaTime;
            puntosDisplay.fontSize = (int)Mathf.Lerp(currentFontSize, targetFontSize, t / smoothTime);
            yield return null;
        }

        puntosDisplay.fontSize = targetFontSize;
    }

    //void cambiarTextoPuntuaje()
    //{
    //    changeColor();

    //    puntosDisplay.ForceMeshUpdate();
    //    var textInfo = puntosDisplay.textInfo;

    //    //Para que el texto se vaya moviendo de arriba abajo de una manera curiosa
    //    for (int i = 0; i < textInfo.characterCount; i++)
    //    {
    //        var charInfo = textInfo.characterInfo[i];

    //        if (!charInfo.isVisible)
    //        {
    //            continue;
    //        }

    //        var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

    //        for (int j = 0; j < 8; j++)
    //        {
    //            var orig = verts[charInfo.vertexIndex + j];
    //            verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
    //        }

    //    }

    //    for (int i = 0; i < textInfo.meshInfo.Length; i++)
    //    {
    //        var meshInfo = textInfo.meshInfo[i];
    //        meshInfo.mesh.vertices = meshInfo.vertices;
    //        puntosDisplay.UpdateGeometry(meshInfo.mesh, i);
    //    }
    //}

    //void changeColor()
    //{
    //    // Calculate the interpolation factor based on time and speed
    //    float t = Mathf.PingPong(Time.time * speed, 1f);

    //    // Interpolate between startColor and endColor using the factor t
    //    Color lerpedColor = Color.Lerp(startColor, endColor, t);

    //    // Apply the lerped color to the text
    //    puntosDisplay.color = lerpedColor;
    //}

    public void SumarPuntos()
    {
        puntos += 1000;
        IncreaseTextSize();
    }

    public void SumarPuntosKrill()
    {
        puntos += 150;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
 
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "Boss") && shieldActive==false )
        {
            StartInvincibility();
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
            StartInvincibility();
            //Destroy(col.gameObject);

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
