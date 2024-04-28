using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : MonoBehaviour
{
    public float spawnTimer;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;
    public GameObject areaDaño;
    public bool puedeDisparar = false;

    [SerializeField] private AudioSource electricSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && puedeDisparar)
        {
            //Instantiate(areaDaño, transform.position, Quaternion.identity);
            StartCoroutine(Explode(0));
            spawnTimer = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Los enemigos solo deberian disparar si entran en el rango del jugador
        if (collision.gameObject.tag == "ProjectileBoundary")
        {
            puedeDisparar = true;
        }

    }   

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        electricSoundEffect.Play();
        Instantiate(areaDaño, transform.position, Quaternion.identity);
    }
}
