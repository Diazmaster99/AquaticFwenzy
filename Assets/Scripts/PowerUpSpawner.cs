using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float moveSpeed;
    public GameObject shieldPowerUp;
    public GameObject fwenzyPowerUp;
    public GameObject grenadePowerUp;

    public float spawnTimer;
    public float spawnMax = 6;
    public float spawnMin = 9;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
        //InvokeRepeating(nameof(), 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);

        if (spawnTimer <= 0)
        {
            StartCoroutine(generatePowerUp());
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

    private IEnumerator generatePowerUp()
    {
        int randomSpawn = Random.Range(6, 11);
        int randomX = Random.Range(-8, 8);
        Vector3 posicionRandom = new Vector3(randomX, transform.position.y, transform.position.z);
        int powerUp = Random.Range(1, 3);
        switch (powerUp)
        {
            case 1:
                Instantiate(fwenzyPowerUp, posicionRandom, Quaternion.identity);
                break;
            case 2:
                Instantiate(shieldPowerUp, posicionRandom, Quaternion.identity);
                break;
            case 3:
                Instantiate(grenadePowerUp, posicionRandom, Quaternion.identity);
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(randomSpawn);


    }
}
