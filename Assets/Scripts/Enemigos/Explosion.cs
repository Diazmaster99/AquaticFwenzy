using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float radius = 5;
    Animator muerte;

    void Start()
    {
        
    }

    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in enemyHit)
        {

            if (col.gameObject.tag != "Enemies")
            {
                if (col.gameObject.tag == "Enemy")
                {
                    Destroy(col.gameObject);
                    PlayerController.puntos += 1000;
                }
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
