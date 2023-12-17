using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrillSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;

    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Player")
        {
            killPlayerSoundEffect.Play();
            PowerUps.gunPowerUpOn = false;
            Time.timeScale = 0f;
            Destroy(col.gameObject);
        }
    }

}
