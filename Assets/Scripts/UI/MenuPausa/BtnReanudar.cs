using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnReanudar : MonoBehaviour
{
    public MenuPausa comandosMenupausa;
    private Animator _animator;
    private AudioSource _sonidoBoton;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sonidoBoton = GetComponent<AudioSource>();
    }

    public void Reanudar()
    {
        _sonidoBoton.Play();
        _animator.SetTrigger("Pulsado");
    }

    public void RealizarAccion()
    {
        comandosMenupausa.Reanudar();
    }

}
