using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject menuOpciones;

    [SerializeField] private GameObject panelOpciones;

    //public AudioSource sonidoBoton;
    public bool juegoPausado = false;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && juegoPausado)
        {
            if(juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Reanudar()
    {
        //sonidoBoton.Play();
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Pausa()
    {
        //sonidoBoton.Play();
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }

    public void Opciones()
    {
        //sonidoBoton.Play();
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
        panelOpciones.SetActive(true);
    }

    public void AtrasOpciones()
    {
        //sonidoBoton.Play();
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
        panelOpciones.SetActive(false);
    }

    public void Reiniciar ()
    {
        //sonidoBoton.Play();
        juegoPausado =false;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        PlayerController.puntos = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Obtener la escena activa (cualquiera que este activa) y que devuelva el nombre de la escena
    }

    public void VolverMenuInicial()
    {
        
        Time.timeScale = 1f;
        //sonidoBoton.Play();
        botonPausa.SetActive(false);
        PlayerController.puntos = 0;

        SceneManager.LoadScene("MenuInicial");//carga el menu inicial
    }

    public void SiguienteNivel()
    {
        Time.timeScale = 1f;
        //sonidoBoton.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
