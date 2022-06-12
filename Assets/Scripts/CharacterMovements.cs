using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float jump;
    public GameObject enemy;
    bool jumping;
    bool movingbackwards;
    bool movingright;
    bool movingleft;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.eulerAngles.x != 0 || this.transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }
        if (this.transform.position.z > 24)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 23.5f);
        }
        if (this.transform.position.z < -24)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -23.5f);
        }
        if (this.transform.position.x > 24)
        {
            transform.position = new Vector3(23.5f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.x < -24)
        {
            transform.position = new Vector3(-23.5f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.y < -1f)
        {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, movementSpeed);
            movingbackwards = false;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movementSpeed);
            movingbackwards = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, movementSpeed * 18);
            //enemy.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, movementSpeed * 18);
            movingright = true;
            movingleft = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -movementSpeed * 18);
            //enemy.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -movementSpeed * 18);
            movingleft = true;
            movingright = false;

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
        if (col.gameObject.tag == "Wall")
        {
            if (movingbackwards)
            {
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, movementSpeed * 18);
            }
            else
            {
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -movementSpeed * 18);
            }
            if (movingright)
            {
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -movementSpeed * 18);
            }
            else if (movingleft)
            {
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, movementSpeed * 18);
            }
            
        }

    }

    void OnTriggerEnter (Collider col)
    {
        Debug.Log(Time.time);
        if (col.gameObject.tag == "Beam")
        {
            Debug.Log(Time.time);
            Debug.Log("HOLA");
        }
    }

}
