using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void CargarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
