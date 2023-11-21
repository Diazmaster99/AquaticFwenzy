using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

        if (collision.gameObject.tag == "DestroyBoundary")
        {
            menuWin.SetActive(true);
        }

        else
        {
            menuWin.SetActive(false);
        }

        if (collision.gameObject.tag == "Projectile")
        {
            menuWin.SetActive(true);
        }

        else //Como mantenerlo desactivado si esa condicion no se cumple
        {
            menuWin.SetActive(false);
        }

        if (collision.gameObject.tag == "ProjectileShoot")
        {
            menuWin.SetActive(true);
        }

        else
        {
            menuWin.SetActive(false);
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
        //FindObjectOfType<MenuWin>().MostrarMenuWin();
}
