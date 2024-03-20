using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpTimer : MonoBehaviour
{
    public UnityEngine.UI.Image wheel;
    public float tiempo;
    public static float tiempoMax=0;
    // Start is called before the first frame update
    void Start()
    {
        wheel = GetComponent<UnityEngine.UI.Image>();
        wheel.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vaciar();
    }

    public void Vaciar() 
    {
        //wheel.fillAmount = tiempo / tiempoMax;
        if (tiempoMax == 3)
        {
            tiempo += 0.0022f;
            wheel.fillAmount = tiempo / tiempoMax;       
            
        }
        if (tiempoMax == 6)
        {
            tiempo += 0.0022f;
            wheel.fillAmount = tiempo / tiempoMax;
            
        }
        if (tiempo >= tiempoMax) 
        {
            tiempo = 0;
            tiempoMax = 0;
            wheel.fillAmount = 0;
        }
    }


}
