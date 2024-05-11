using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpciones : MonoBehaviour
{
    public MenuPausa comandosMenupausa;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Opciones()
    {
        animator.SetTrigger("Pulsado");
    }

    public void RealizarAccion()
    {
        comandosMenupausa.Opciones();
    }

}
