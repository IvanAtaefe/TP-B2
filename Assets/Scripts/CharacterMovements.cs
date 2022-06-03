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
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationSpeed);
          
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            jumping = true;
        }

        void OnCollisionEnter(Collision col){
            Debug.Log(col.gameObject.tag);
            if (col.gameObject.tag == "ground")
            {
                jumping = false;
            }
        }
        
        void Rotate(){
            float x = Mathf.Cos(rotationSpeed) * movementSpeed;
            float z = Mathf.Sin(rotationSpeed) * movementSpeed;
            transform.position = new Vector3(x, 0f, z);
        }
    }
}
