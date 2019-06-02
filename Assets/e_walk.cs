using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_walk : MonoBehaviour
{

    public float rotationRate = 100;
    public float moveRate = 90;
    public bool walkTurn = true;
    private Rigidbody rb;
    private Vector3 position;
    private  Vector3 rotation;
    public float initialX;
    public float initialRotation;
    public float turning = 1;
    public float xDistance = 20;
    public bool isZ = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        position = gameObject.transform.position;
        rotation = gameObject.transform.eulerAngles;
        float pos = isZ ? position[2] : position [0];
        initialX = Math.Abs(pos);
        initialRotation = Math.Abs(rotation[1]);
    }

    // Update is called once per frame
    void Update()
    {
        position = gameObject.transform.position;
        float pos = isZ ? position[2] : position [0];
        float x = Math.Abs(pos);
        float dif = Math.Abs(initialX - x);

        // rotation = gameObject.transform.eulerAngles;
        // float r = Math.Abs(rotation[1]);
        // float difR = Math.Abs(initialRotation - r);

        if(dif >= xDistance) {
            walkTurn = false;
            initialX = x;
        }
        // Debug.Log("R: " + difR);
        // if(difR >= 180) {
        //     walkTurn = true;
        //     initialRotation = r;
        //     turning *= -1;
        // }

        if(walkTurn) {
            Move();
        } else {
            Turn();
        }
    }

    private void Move() {
        rb.AddForce(transform.forward * moveRate);
    }

    private void Turn() {
        // transform.Rotate(0, turning * rotationRate * Time.deltaTime, 0);
        transform.Rotate(0, 180, 0);
        walkTurn = true;
    }
}
