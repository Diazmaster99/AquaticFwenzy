using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private AudioSource killPlayerSoundEffect;
    public float moveSpeed = 2;
    Animator muerte;
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
            killPlayerSoundEffect.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Projectile")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == "DestroyBoundary"
            || collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
    public void Muerte()
    {
        Destroy(gameObject);

    }

    //public void Muerte2()
    //{
    //    muerte = this.gameObject.GetComponent<Animator>();
    //    muerte.SetBool("Muerte", false);

    //}
}
   