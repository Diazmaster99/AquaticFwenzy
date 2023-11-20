using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;

    public void Update()
    {
        if (Input .GetKeyUp(KeyCode.Escape))
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

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado=false;
        Time.timeScale = 1f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(false);
    }

    public void Reiniciar ()
    {
        juegoPausado=true;
        botonPausa.SetActive(false); 
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverMenuInicial()
    {
        botonPausa.SetActive(false);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name); //descarga de memoria la escena actual
     
        SceneManager.LoadScene("MenuInicial");//carga el menu inicial
    }
    
}
