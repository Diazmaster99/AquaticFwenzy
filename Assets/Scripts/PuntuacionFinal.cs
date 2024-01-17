using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuacionFinal : MonoBehaviour
{
    public Puntuaje puntuaje;
    TMP_Text puntuacion;

    // Start is called before the first frame update
    void OnEnable() //Se llama cuando el objeto se habilita y se ativa
    {
        puntuacion = GetComponent<TMP_Text>();
        puntuacion.text = Mathf.RoundToInt(puntuaje.puntos).ToString(); //Proporciona funciones matemeticas para poder trabajar con nº en punto flotante
        //RoundToInt redondea un nº en punto flotante al entero mas cercano
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
