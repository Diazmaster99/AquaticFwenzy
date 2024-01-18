using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    public float moveSpeed;
    public static int vidaBoss = 10;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.up);

        if (vidaBoss <= 0)
        {
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

        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            killPlayerSoundEffect.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Projectile"
            || collision.gameObject.tag == "Shield")
        {
            vidaBoss--;
        }

    }
    public void Muerte()
    {
        Destroy(gameObject);
    }
}
    

