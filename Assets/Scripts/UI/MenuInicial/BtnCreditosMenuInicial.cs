using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCreditosMenuInicial : MonoBehaviour
{
    public BotonesMenuInicial comandosMenuInicial;
    private Animator _animator;
    private AudioSource _sonidoBoton;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sonidoBoton = GetComponent<AudioSource>();
    }

    public void Creditos()
    {
        _sonidoBoton.Play();
        _animator.SetTrigger("Pulsado");
    }

    public void RealizarAccion()
    {
        comandosMenuInicial.Creditos();
    }
}
