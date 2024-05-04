using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            wheel.fillAmount += 1.0f / tiempoMax * Time.deltaTime;
        }
        if (tiempoMax == 6)
        {
            wheel.fillAmount += 1.0f / tiempoMax * Time.deltaTime;

        }
        if (wheel.fillAmount >= 1) 
        {
            tiempo = 0;
            tiempoMax = 0;
            wheel.fillAmount = 0;
        }
    }


}
