using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuInicial : MonoBehaviour
{
    public AudioSource sonidoBoton;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject panelOpciones;


    public void Opciones()
    {
        //sonidoBoton.Play();
        menuOpciones.SetActive(true);
        panelOpciones.SetActive(true);
    }

    public void atrasOpciones()
    {
        //sonidoBoton.Play();
        menuOpciones.SetActive(false);
        panelOpciones.SetActive(false);
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void VolverMenuInicial()
    {
        SceneManager.LoadScene("MenuInicial");
    }

}
