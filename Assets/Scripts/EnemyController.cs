using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private AudioSource killEnemySoundEffect;
    public float moveSpeed;
    private int contador=0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(contador < 1)
        {
            if (collision.gameObject.tag != "Enemies")
            {

                if (collision.gameObject.tag == "Enemy")
                {
                    killEnemySoundEffect.Play();
                    contador++; 
                }
            }
        }
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }


    }
}
   