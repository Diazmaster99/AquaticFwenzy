using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantarraya : MonoBehaviour
{
    public float spawnTimer;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;
    public GameObject projectilePrefab;
    public bool puedeDisparar = false;
    public GameObject salidaDisparo, salidaDisparo2;
    // Start is called before the first frame update
    void Start()
    {
        //spawnTimer = Random.Range(spawnMin, spawnMax);
        spawnTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && puedeDisparar)
        {
            Instantiate(projectilePrefab, salidaDisparo.transform.position, Quaternion.Euler(0f, 0f, -180f)); // -180 degrees clockwise rotation around z-axis
            Instantiate(projectilePrefab, salidaDisparo2.transform.position, Quaternion.Euler(0f, 0f, -180f)); // -180 degrees clockwise rotation around z-axis
            //spawnTimer = Random.Range(spawnMin, spawnMax);
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
}
