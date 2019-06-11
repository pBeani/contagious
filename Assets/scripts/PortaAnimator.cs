using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaAnimator : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Move", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetInteger("Move", 1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetInteger("Move", 2);
        }
    }
}
