using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;

    public void CargarEscena(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menuinicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
