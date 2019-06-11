using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour {

    public Slider barraVida;
    public float vidaMaxima = 100;
    public GameObject panelBox;
    public TextAsset arq;
    public TextAsset entradaTxt;
    public string[] texto;
    public string[] textoEntrada;
    public Text textoMensagem;
    public Text textoMensagemEntrada;
    public int linhaAtual;
    public int linhaAtualEntrada = 0;
    public bool startChat = false;
    public bool chatStarted = false;
    public ParticleSystem particlep;


    void Start() {

        ParticleSystem.EmissionModule pEmission = particlep.emission;
        pEmission.rateOverTime = 0;
        barraVida.minValue = 0;
        barraVida.maxValue = 500;
        barraVida.value = barraVida.maxValue;

        panelBox.SetActive(false);
        textoMensagem.enabled = false;
        if (arq!=null)
        {
            texto = (arq.text.Split('\n'));
        }

        if (entradaTxt!=null)
        {
            textoEntrada = (entradaTxt.text.Split('\n'));
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
            UpdateBarra(10);
        }
        if(other.gameObject.name.Contains("boss")) {
            textoMensagem.enabled = true;
            textoMensagemEntrada.enabled = false;
            panelBox.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
            UpdateBarra(1);
        }
        if(other.gameObject.name.Contains("boss")) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (linhaAtual >= texto.Length)
                {
                    SceneManager.LoadScene("vitoria"); 
                }            
                else {
                    textoMensagem.text = texto[linhaAtual];
                }
                linhaAtual += 1;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.name.Contains("boss")) {
            panelBox.SetActive(false);
            linhaAtual = 0;
        }
    }

    private void Update()
    {


        if (barraVida.value >= vidaMaxima) barraVida.value = vidaMaxima;
        if (barraVida.value <barraVida.minValue) barraVida.value = barraVida.minValue;

        if (Input.GetKeyDown(KeyCode.UpArrow) && !chatStarted) {
            startChat = true;
            chatStarted = true;
            panelBox.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && startChat)
            {
                if (linhaAtualEntrada >= textoEntrada.Length)
                {
                    panelBox.SetActive(false);
                    startChat = false;
                    textoMensagemEntrada.enabled = false;     
                }            
                else {
                    textoMensagemEntrada.text = textoEntrada[linhaAtualEntrada];
                }
                linhaAtualEntrada += 1;
            }
    }

    void UpdateBarra(float dano) {
        ParticleSystem.EmissionModule pEmission = particlep.emission;
       // float x = 
           pEmission.rateOverTime= pEmission.rateOverTime.constant + 0.1f;
        barraVida.value -= dano;        
        if (barraVida.value <= barraVida.minValue)
        {
            SceneManager.LoadScene("FimDeJogo");         
        }
    }
}
