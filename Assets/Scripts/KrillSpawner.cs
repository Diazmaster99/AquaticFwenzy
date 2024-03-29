using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrillSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    private Transform _transform;
    private Vector2 initialPosition;
    public int moveSpeed;

    void Start()
    {
        _transform = this.gameObject.transform;
        initialPosition = _transform.position;
    }

    void Update()
    {
        _transform.position = new Vector2(Mathf.PerlinNoise(-5f, 11f), 11);
    }
    
    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Shield" || col.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
        
   
        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Projectile" ) && PlayerController.shieldActive == false )
        {
            killPlayerSoundEffect.Play();
            PowerUps.gunPowerUpOn = false;
            //Destroy(gameObject);
        }  
   
    }
    
    }
