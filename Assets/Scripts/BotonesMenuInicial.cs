using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesMenuInicial : MonoBehaviour
{
    public AudioSource sonidoBoton;
    [SerializeField] private GameObject menuOpciones;


    public void Opciones()
    {
        //sonidoBoton.Play();
        menuOpciones.SetActive(true);
    }

    public void atrasOpciones()
    {
        //sonidoBoton.Play();
        menuOpciones.SetActive(false);
    }
}
