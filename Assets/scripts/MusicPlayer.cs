using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource som;
    public AudioClip[] audios;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            som.clip = audios[0];
            som.Play();
            Debug.Log("M");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            som.clip = audios[1];
            Debug.Log("N");
        }
        
    }
}
