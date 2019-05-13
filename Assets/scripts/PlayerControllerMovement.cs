using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string rotateInputAxis = "Horizontal";

    public float rotationRate = 270;
    public float moveRate = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float rotateAxis = Input.GetAxis(rotateInputAxis);

        ApplyInput(moveAxis, rotateAxis);
    }

    private void ApplyInput(float move, float rotate)
    {
        Move(move);
        Turn(rotate);
    }

    private void Move(float input) {
        if(input < 0) {
            input = 0;
        }

        rb.AddForce(transform.forward * input * moveRate);
    }

    private void Turn(float input) {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
