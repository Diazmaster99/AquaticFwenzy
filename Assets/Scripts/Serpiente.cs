using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpiente : MonoBehaviour
{
    public float spawnTimer;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;
    public GameObject projectilePrefab;
    public bool puedeDisparar = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
