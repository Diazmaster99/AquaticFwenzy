using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnReiniciar : MonoBehaviour
{
    public MenuPausa comandosMenupausa;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Reiniciar()
    {
        animator.SetTrigger("Pulsado");
    }

    public void RealizarAccion()
    {
        comandosMenupausa.Reiniciar();
    }

}
