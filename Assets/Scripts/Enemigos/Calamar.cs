using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamar : MonoBehaviour
{
    public float spawnTimer;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;
    public GameObject projectilePrefabAbajo, projectilePrefabArriba, projectilePrefabIzquierda, projectilePrefabDerecha;
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
            // Instantiate the prefabs with different rotations
            Instantiate(projectilePrefabAbajo, transform.position, Quaternion.Euler(0f, 0f, 0f)); // No rotation
            Instantiate(projectilePrefabArriba, transform.position, Quaternion.Euler(0f, 0f, 180f)); // 90 degrees clockwise rotation around z-axis
            Instantiate(projectilePrefabIzquierda, transform.position, Quaternion.Euler(0f, 0f, 270f)); // 180 degrees clockwise rotation around z-axis
            Instantiate(projectilePrefabDerecha, transform.position, Quaternion.Euler(0f, 0f, -270f)); // 45 degrees anti-clockwise rotation around z-axis

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
