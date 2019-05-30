using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider barraVida;
    public float vidaMaxima = 1000.0f;

    private void Start()
    {
        barraVida.minValue = 0;
        barraVida.maxValue = 10000;
        barraVida.value = vidaMaxima;

    }

    private void Update()
    {
        controlevida();

    }

    private void controlevida()
    {
        if (barraVida.value >= vidaMaxima) barraVida.value = vidaMaxima;
        if (barraVida.value < barraVida.minValue) barraVida.value = barraVida.minValue;
    }
}
