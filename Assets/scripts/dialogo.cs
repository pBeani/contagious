using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogo : MonoBehaviour
{
    private bool dialogoConcluido = false;
    public GameObject panelBox;
    public TextAsset arq;
    public string[] texto;
    public Text textoMensagem;
    

    private int fimDaLinha;
    private int linhaAtual;    

    // Start is called before the first frame update
    void Start()
    {
        panelBox.SetActive(false);

        if (arq!=null)
        {
            texto = (arq.text.Split('\n'));
        }
        if (fimDaLinha == 0)
        {
            fimDaLinha = texto.Length;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(linhaAtual < fimDaLinha)
            {
                textoMensagem.text = texto[linhaAtual];
            }
            if (panelBox.activeSelf)
            {
                linhaAtual += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (linhaAtual >= fimDaLinha)
        {
            panelBox.SetActive(false);
            SceneManager.LoadScene("vitoria");         
        }
        
    }
    
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("personagem"))
        {                    
            panelBox.SetActive(true);
        }
    }

    
}
