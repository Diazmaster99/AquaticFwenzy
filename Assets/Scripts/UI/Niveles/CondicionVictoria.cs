using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionVictoria : MonoBehaviour
{
    public GameObject menuwin;
    public float moveSpeed;
    private bool final = false;
    private AudioSource sonidoVictoria;
    // Start is called before the first frame update
    void Start()
    {
        sonidoVictoria = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!final)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            final = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            sonidoVictoria.Play();
            menuwin.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
