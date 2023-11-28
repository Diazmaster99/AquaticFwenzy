using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionVictoria : MonoBehaviour
{
    public GameObject menuwin;
    public float moveSpeed;
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
        if (collision.gameObject.tag == "DestroyBoundary")
        {
            menuwin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    
    
}
