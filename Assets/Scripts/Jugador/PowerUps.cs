using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float moveSpeed;
    public int powerUpID;
    public static bool gunPowerUpOn = false;
    [SerializeField] private AudioSource powerUpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.SetActive(false);
            powerUpSoundEffect.Play();
            PlayerController player = collision.GetComponent<PlayerController>();

            if(powerUpID == 1 && gunPowerUpOn == false)
            {
                gunPowerUpOn = true;
                player.CanFastShoot();
            }
            if (powerUpID == 2)
            {
                player.ShieldPowerUpOn();
            }
            if(powerUpID==3 && gunPowerUpOn == false) 
            {
                gunPowerUpOn = true;
                player.CanGrenadeLauncher();
            }

            Destroy(gameObject, 0.35f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == "DestroyBoundary")
        {
            Destroy(gameObject);
        }
    }
}
