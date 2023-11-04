using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    [SerializeField] private AudioSource shootSoundEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            shootSoundEffect.Play();
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
