using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    public void CargarEscena(int index)
    {
        SceneManager.LoadScene(index + 1);
    }

    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre + 1);
    }

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuWin;

    [SerializeField] private GameObject puntuaje;



    //private bool juegoPausado = false;

    public void Update()
    {
   
    }

    public void Ganar()
    {
        //juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuWin.SetActive(true);
        puntuaje.SetActive(true);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
        //FindObjectOfType<MenuWin>().MostrarMenuWin();
}
