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
    public GameObject shield;
    [SerializeField] private GameObject botonGameOver;
    [SerializeField] private GameObject botonMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
        ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
        if (fastShoot==true)
        {       
            projectileShoot.FastShootOn();
        }
        else 
        {
            projectileShoot.FastShootOff();
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
 
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE")
        {
            botonMenu.SetActive(false);
            botonGameOver.SetActive(true);
            Time.timeScale = 0f;
            Destroy(this.gameObject);
            //jugador.drag = 20;
        }

    }

    
    public void CanFastShoot()
    {
        fastShoot = true;
        StartCoroutine (FastShootDownRoutine());
    }

    public void ShieldPowerUpOn() 
    {
        shieldActive = true;
        shield.SetActive(true);
        StartCoroutine (ShieldDownRoutine());
    }
    public IEnumerator FastShootDownRoutine() 
    {
        yield return new WaitForSeconds(3f);
        fastShoot = false;
    }

    public IEnumerator ShieldDownRoutine() 
    {
        yield return new WaitForSeconds(7f);
        shield.SetActive(true);
        shieldActive = false;

    }
}
