using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDaño : MonoBehaviour
{
    public float radius = 2;


    void Start()
    {

    }

    void Update()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in playerHit)
        {
            
                if (col.gameObject.tag == "Player")
                {
                    Destroy(col.gameObject);
                }
            
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
