using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject menuWin;

    [SerializeField] private GameObject menuGameOver;

    public bool juegoPausado = false;

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
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar ()
    {
        juegoPausado=false;
        botonPausa.SetActive(true); 
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Obtener la escena activa (cualquiera que este activa) y que devuelva el nombre de la escena
    }

    public void VolverMenuInicial()
    {
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name); //descarga de memoria la escena actual
     
        SceneManager.LoadScene("MenuInicial");//carga el menu inicial
    }

    public void MenuWin()
    {
        juegoPausado = true;
        menuWin.SetActive(true);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        //FindObjectOfType<MenuWin>().MostrarMenuWin();
        SceneManager.LoadScene("MenuWin");
    }

    public void MenuGameOver()
    {
        juegoPausado = true;
        menuGameOver.SetActive(true);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuGameOver");
    }

}
