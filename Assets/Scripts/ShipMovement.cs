using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Script para poner a los enemigos/grupos de enemigos que van de lado a lado en pantalla 
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
        //if (collision.gameObject.tag == "Boundary")
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        //    moveSpeed *= -1; 
        //}
    }
}
