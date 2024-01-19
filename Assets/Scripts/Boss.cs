using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    [SerializeField] private AudioSource killBossSoundEffect;
    public float moveSpeed;
    public static int vidaBoss = 10;
    // Start is called before the first frame update
    void Start()
    {
        vidaBoss = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);

        if (vidaBoss <= 0)
        {
            killBossSoundEffect.Play();
            Muerte();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            moveSpeed *= -1;
        }

        if (collision.gameObject.tag == "Player" && PlayerController.shieldActive==false)
        {
            vidaBoss--;
            killPlayerSoundEffect.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player" && PlayerController.shieldActive == true)
        {
            vidaBoss--;        
        }

        if (collision.gameObject.tag == "Projectile")
        {
            vidaBoss--;
        }

    }
    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && PlayerController.shieldActive == false)
        {
            // botonMenu.SetActive(false);
            // botonGameOver.SetActive(true);
            killPlayerSoundEffect.Play();
            PowerUps.gunPowerUpOn = false;
            Time.timeScale = 0f;
            Destroy(col.gameObject);
        }
    }

    public void Muerte()
    {    
        Destroy(gameObject);      
    }
}
    

