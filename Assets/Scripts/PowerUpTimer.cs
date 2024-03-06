using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTimer : MonoBehaviour
{
    public Image wheel;
    // Start is called before the first frame update
    void Start()
    {
        wheel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Vaciar(int tiempo) 
    {
        if (tiempo == 3)
        {

        }
        else 
        {

        }
    }


}
