using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject menuPausa;

    public void GameOver()
    {
        menuPausa.SetActive(false);
        menuGameOver.SetActive(true);
    }
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
        menuPausa.SetActive(false);
        menuGameOver.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MenuInicial(string Menuinicial)
    {
        SceneManager.LoadScene("Menuinicial");
        Time.timeScale = 1f;
    }

    public void Salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
