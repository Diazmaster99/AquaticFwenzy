using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuaje : MonoBehaviour
{
    private float puntos;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        puntos += Time.deltaTime;
        textMesh.text = puntos.ToString("0");
        puntos++;
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos = Time.deltaTime;
        puntos += puntosEntrada;
        Destroy(gameObject);
            
    }
}
