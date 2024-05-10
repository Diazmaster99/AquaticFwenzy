using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCreditos : MonoBehaviour
{
    private AudioSource _sonido;
    // Start is called before the first frame update
    void Start()
    {
        _sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _sonido.Play();
    }
}
