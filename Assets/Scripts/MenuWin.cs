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

    [SerializeField] private GameObject botonReanudar;

    [SerializeField] private GameObject menuWin;

    private bool juegoPausado = false;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Cerrar();
            }
            else
            {
                Salir();
            }
        }
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void MostrarMenuWin()
    {
        FindObjectOfType<MenuWin>().MostrarMenuWin();
    }
}
