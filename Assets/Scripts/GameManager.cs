using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int vidas = 3;
    public GameObject botonPausa;
    public GameObject botonGameOver;
    public PlayerController playerController;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PerderVida()
    {
        vidas--;

        if(vidas <= 0)
        {
            botonPausa.SetActive(false);
            botonGameOver.SetActive(true);
            playerController.Morir();
        }
        else
        {
            ActualizarVidas();
        }
    }

    public void RecuperarVidas()
    {
        if(vidas < 3)
        {
            vidas++;
            ActualizarVidas();
        }
    }

    public void ActualizarVidas()
    {
        botonPausa.SetActive(true);
        botonGameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PerderVida();
        }
    }
}
