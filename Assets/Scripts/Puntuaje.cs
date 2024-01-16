using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuaje : MonoBehaviour
{
    public float puntos;

    private TextMeshProUGUI textMesh;

    public TextMeshProUGUI puntosFinales;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        puntos += Time.deltaTime;
        textMesh.text = puntos.ToString("0");
       
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos = Time.deltaTime;
        puntos += puntosEntrada;
            
    }


}
