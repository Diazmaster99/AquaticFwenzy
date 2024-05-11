using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnReanudar : MonoBehaviour
{
    public MenuPausa comandosMenupausa;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Reanudar()
    {
        animator.SetTrigger("Pulsado");
    }

    public void RealizarAccion()
    {
        comandosMenupausa.Reanudar();
    }

}
