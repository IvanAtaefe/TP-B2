﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    float rotation;
    float position;
    public float jump;
    bool jumping;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation += rotationSpeed;
            transform.Translate(movementSpeed, 0, 0);
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation -= rotationSpeed;
            transform.Translate(-movementSpeed, 0, 0);
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            jumping = true;
        }

        void OnCollisionEnter(Collision col){
            if (col.gameObject.tag == "ground")
            {
                jumping = false;
            }
        }
    }
}
