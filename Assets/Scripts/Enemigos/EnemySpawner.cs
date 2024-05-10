using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float moveSpeed;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public float spawnTimer;
    public float timeAlive;
    public float spawnMax = 3;
    public float spawnMin = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
        InvokeRepeating(nameof(subirDificultad), 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        timeAlive += Time.deltaTime;
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);

        if (spawnTimer <= 0)
        {
            StartCoroutine(generateEnemy());
            spawnTimer = Random.Range(spawnMin, spawnMax);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Boundary")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moveSpeed *= -1;
            }
    }

    private IEnumerator generateEnemy()
    {
        int randomSpawn = Random.Range(5, 10);

        int enemyType = Random.Range(1, 3);
        switch (enemyType)
        {
            case 1:
                Instantiate(enemy1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy3, transform.position, Quaternion.identity);
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(randomSpawn);

        
    }

    private void subirDificultad()
    {
        if (spawnMax <= 0)
        {
            spawnMax = 1;
        }
        spawnMax--;
    }

}
