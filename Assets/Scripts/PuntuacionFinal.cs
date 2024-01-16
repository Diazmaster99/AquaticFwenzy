using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuacionFinal : MonoBehaviour
{
    public Puntuaje puntuaje;
    TMP_Text puntuacion;

    // Start is called before the first frame update
    void OnEnable()
    {
        puntuacion = GetComponent<TMP_Text>();
        puntuacion.text = Mathf.RoundToInt(puntuaje.puntos).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
