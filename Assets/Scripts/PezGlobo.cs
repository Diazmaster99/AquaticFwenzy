using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezGlobo : MonoBehaviour
{
    public float spawnTimer;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;
    public GameObject projectilePrefab, projectilePrefab2, projectilePrefab3, projectilePrefab4;
    public bool puedeDisparar = false;
    // Start is called before the first frame update
    void Start()
    {
        //spawnTimer = Random.Range(spawnMin, spawnMax);
        spawnTimer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && puedeDisparar)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Instantiate(projectilePrefab2, transform.position, Quaternion.LookRotation(Vector3.forward * 90));
            Instantiate(projectilePrefab3, transform.position, Quaternion.LookRotation(Vector3.forward * -180));
            Instantiate(projectilePrefab4, transform.position, Quaternion.LookRotation(Vector3.forward * -45));
            //spawnTimer = Random.Range(spawnMin, spawnMax);
            spawnTimer = 1.5f;
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
