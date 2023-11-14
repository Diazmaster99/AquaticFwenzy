using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput;
    public bool fastShoot = false;
    [SerializeField] private GameObject botonGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
        if (fastShoot)
        {
            ProjectileShoot projectileShoot = GetComponent<ProjectileShoot>();
            projectileShoot.FastShootOn();
        }
        else 
        {

        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
 
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "ProjectileE")
        {
            botonGameOver.SetActive(true);
            Time.timeScale = 0f;
            Destroy(this.gameObject);
            //jugador.drag = 20;
        }

    }

    
    public void CanFastShoot()
    {
        fastShoot = true;
    }

    public IEnumerator FastShootDownRoutine() 
    {
        yield return new WaitForSeconds(3f);
        fastShoot = false;
    }
}
