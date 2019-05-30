using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColision : MonoBehaviour {

    int damage;
    public Slider barraVida;
    public float vidaMaxima = 100;



    void Start() {
        this.damage = 0;
        barraVida.minValue = 0;
        barraVida.maxValue = 100;
        barraVida.value = barraVida.maxValue;        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
            UpdateDamage(10);
            UpdateBarra(10);
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
            UpdateDamage(1);
            UpdateBarra(1);
        }

    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
        }
    }

    void UpdateDamage(int value) {             
        damage += value;
        GameObject placar = GameObject.Find("placar");
        placar.gameObject.GetComponent<Text>().text = this.damage.ToString();
    }
    private void Update()
    {
        if (barraVida.value >= vidaMaxima) barraVida.value = vidaMaxima;
        if (barraVida.value <barraVida.minValue) barraVida.value = barraVida.minValue;
    }

    void UpdateBarra(float dano) {   
        barraVida.value -= dano;        
        if (barraVida.value <= barraVida.minValue)
        {
            Debug.Log("infectado totalmente");            
        }
    }
}
