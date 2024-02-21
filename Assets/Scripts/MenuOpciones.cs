using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{
    private bool fullscreen = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FullScreen() {
        if (!fullscreen)
        {
            Screen.fullScreen = true;
        }
        else
        {
            fullscreen = false;
        }
    }

    private void ChangeResolution()
    {
        int numero = 1;
        switch (numero)
        {
            case 1:
                Screen.SetResolution(1920, 1080, false);
                break;
            case 2:
                Screen.SetResolution(1420, 960, false);
                break;
            case 3:
                //Screen.SetResolution(800, 600, false);
                break;
            default:
                break;
        }
        
    }

}
