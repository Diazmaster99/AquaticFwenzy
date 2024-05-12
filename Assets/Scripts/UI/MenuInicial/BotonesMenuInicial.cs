using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesMenuInicial : MonoBehaviour
{
    public AudioSource sonidoBoton;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject panelOpciones;

    public Slider sliderMaster;
    public Slider sliderMusica;
    public Slider sliderSFX;

    public void Opciones()
    {
        //sonidoBoton.Play();
        menuOpciones.SetActive(true);
        panelOpciones.SetActive(true);
    }

    public void atrasOpciones()
    {
        PlayerPrefs.SetFloat("Master", sliderMaster.value);
        PlayerPrefs.SetFloat("Musica", sliderMusica.value);
        PlayerPrefs.SetFloat("SFX", sliderSFX.value);
        PlayerPrefs.Save();

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
