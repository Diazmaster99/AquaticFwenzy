using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject grenadePrefab;
    public float canFire = 0.0f;
    public float fireRate = 0.35f;
    public bool grenadeLauncherOn=false;
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform boquilla;

    public Animator shoot;

    void Start()
    {
        projectilePrefab.GetComponent<Projectile>().player = player;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")) 
        {
            if (Time.time > canFire)
            {
                if (grenadeLauncherOn) 
                {
                    shootSoundEffect.Play();
                    Instantiate(grenadePrefab, boquilla.position, Quaternion.identity);                   
                }
                else
                {                 
                    shoot.SetInteger("Shooting",1);
                    shootSoundEffect.Play();
                    Instantiate(projectilePrefab, boquilla.position, Quaternion.identity);
                    //player.SumarPuntos();
                }        
                canFire = Time.time + fireRate;    
            }
        }
        else
        {
            shoot.SetInteger("Shooting", 0);
        }
    }

    public void FastShootOn()
    {
        fireRate = 0.1f;
    }
    public void FastShootOff()
    {
        fireRate = 0.35f;
        PowerUps.gunPowerUpOn = false;
        grenadeLauncherOn = false;
    }

    public void GrenadeLauncherOn()
    {
        fireRate = 0.8f;
        grenadeLauncherOn = true;
    }
}
