using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float canFire = 0.0f;
    public float fireRate = 0.35f;
    [SerializeField] private AudioSource shootSoundEffect;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")) 
        {
            if (Time.time > canFire)
            {

                shootSoundEffect.Play();
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                canFire = Time.time + fireRate;    
            }
        }
    }

    public void FastShootOn()
    {
        fireRate = 0.1f;
    }
    public void FastShootOff()
    {
        fireRate = 0.35f;
    }

    public void GrenadeLauncherOn()
    {
        fireRate = 0.8f;
    }
}
