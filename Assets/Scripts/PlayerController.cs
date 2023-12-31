using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput;
    public bool fastShoot = false;
    public bool shieldActive = false;
    public bool grenadeLauncher = false;
    public GameObject shieldPrefab;
    public PowerUps powerUps;
    [SerializeField] private GameObject botonGameOver;
    [SerializeField] private GameObject botonMenu;
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject MenuWin;
    [SerializeField] private AudioSource shieldDown;

    //[SerializeField] private AudioSource killPlayerSoundEffect;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        PowerUps.gunPowerUpOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //hInput = Input.GetAxisRaw("Horizontal");
        //transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);

        //if (Input.GetButtonDown(KeyCode.W))
        //{
        //    transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetButtonDown(KeyCode.A))
        //{
        //    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetButtonDown(KeyCode.S))
        //{
        //    transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetButtonDown(KeyCode.D))
        //{
        //    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //}

        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        }

    }



    void OnTriggerEnter2D(Collider2D col)
    {
 
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE") && shieldActive==false )
        {
            botonMenu.SetActive(false);
            botonGameOver.SetActive(true);
            PowerUps.gunPowerUpOn = false;
            Time.timeScale = 0f;
            Destroy(this.gameObject);
            //jugador.drag = 20;
        }
    }

    private void OnParticleCollision(GameObject col)
    {
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE") && shieldActive == false)
        {
            //killPlayerSoundEffect.Play();
            botonMenu.SetActive(false);
            botonGameOver.SetActive(true);
            PowerUps.gunPowerUpOn = false;
            Time.timeScale = 0f;
            Destroy(this.gameObject);
            //jugador.drag = 20;
        }
    }

    public void CanFastShoot()
    {
        //fastShoot = true;
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOn();
        StartCoroutine (FastShootDownRoutine());
    }

    public void ShieldPowerUpOn() 
    {
        shieldActive = true;
        shieldPrefab.SetActive(true);
        StartCoroutine (ShieldDownRoutine());
    }

    public void CanGrenadeLauncher()
    {
        grenadeLauncher = true; 
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.GrenadeLauncherOn();
        StartCoroutine(GrenadeLauncherDownRoutine());
    }
    public IEnumerator FastShootDownRoutine() 
    {
        yield return new WaitForSeconds(3f);
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOff();
        //fastShoot = false;
    }

    public IEnumerator ShieldDownRoutine() 
    {
        yield return new WaitForSeconds(3f);
        shieldDown.Play();
        shieldPrefab.SetActive(false);
        shieldActive = false;
    }
    public IEnumerator GrenadeLauncherDownRoutine()
    {
        yield return new WaitForSeconds(6f);     
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        projectileShoot.FastShootOff();
        grenadeLauncher = false;
    }
}
