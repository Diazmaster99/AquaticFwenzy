using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{
    //private bool fullscreen = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullScreen(bool fullscreen) {

        Debug.Log("Fullscreen es: "+fullscreen);
        Screen.fullScreen = fullscreen;

    }

    public void ChangeResolution(int numero)
    {
        Debug.Log("resolution es: " + numero);
        //int numero = 1;
        switch (numero)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1420, 960, true);
                break;
            case 2:
                //Screen.SetResolution(800, 600, false);
                break;
            default:
                break;
        }
        
    }

}
