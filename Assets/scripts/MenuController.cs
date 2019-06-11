using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;






public class MenuController : MonoBehaviour
{    
    public void CarregaScene1() {
        SceneManager.LoadScene("Explicacao");
    }

    public void Quit()  
    {
        Application.Quit();

    }

}
