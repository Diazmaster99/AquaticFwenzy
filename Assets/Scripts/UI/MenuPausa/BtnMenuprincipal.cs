using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMenuprincipal : MonoBehaviour
{
    public MenuPausa comandosMenupausa;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void VolverMenuInicial()
    {
        animator.SetTrigger("Pulsado");
    }

    public void RealizarAccion()
    {
        comandosMenupausa.VolverMenuInicial();
    }

}