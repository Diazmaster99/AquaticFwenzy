using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyController : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] private AudioSource killPlayerSoundEffect;
    public float spawnTimer;
    public float puntos;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;
    public bool puedeDisparar = false;
    public float moveSpeed=2;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && puedeDisparar)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Los enemigos solo deberian disparar si entran en el rango del jugador
         if (collision.gameObject.tag == "ProjectileBoundary")
         {
            puedeDisparar = true;   
         }

        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            killPlayerSoundEffect.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject, 1.1f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == "DestroyBoundary" 
            || collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //puntos++;
        }
    }

}
   