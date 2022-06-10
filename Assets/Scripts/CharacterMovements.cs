using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    float rotation;
    float position;
    public float jump;
    public Transform centerPoint;
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
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, movementSpeed * 18);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -movementSpeed * 18);
          
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            jumping = true;
        }

        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            jumping = false;
        }
        
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Beam")
        {
            Debug.Log("HOLA");
        }
    }

}
