using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovements : MonoBehaviour
{
    public AudioSource jumpings;
    public float movementSpeed;
    public float rotationSpeed;
    public AudioClip jumps;
    public AudioClip daños;
    public float jump;
    public GameObject enemy;
    bool jumping;
    bool movingbackwards;
    bool movingright;
    bool movingleft;
    bool invincible = false;
    public Text tiempo;
    public Text vidas;
    public Text ataquet;
    public int vidasmax;
    public float invinsibletime;
    public RawImage vida;
    public RawImage ataque;
    public float cargarataques;
    float vidaenemy = 1;
    float endofinvinsible;
    float ataquep = 0;
    float cargarataque;
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Corregir Posición
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

        //Invencibilidad
        if (Mathf.Floor(Time.time) > endofinvinsible)
        {
            invincible = false;
        }

        //UI
        tiempo.text = "Tiempo: " + Mathf.Floor(Time.time);
        vidas.text = "Vidas: " + vidasmax;
        if (ataquep < 1  && Time.time > cargarataque)
        {
            ataquep += 0.01f;
            ataque.transform.localScale = new Vector3(ataquep, 1, 0);
            ataquet.text = "%" + Mathf.Floor(ataquep * 100);
            cargarataque = Time.time + cargarataques;
        }
        else if (ataquep >= 1)
        {
            ataquet.text = "¡Ataque Cargado!";
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && ataquep >= 1)
        {
            ataquep = 0;
            vidaenemy -= 0.1f;
            vida.transform.localScale = new Vector3(vidaenemy, 1, 0);
        }

        

        //Movimiento
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
            jumpings.clip = jumps;
            jumpings.Play();
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
            //CorregirPosición
            if (movingbackwards)
            {
                transform.Translate(0, 0, movementSpeed);
            }
            else if (movingright)
            {
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -movementSpeed * 18);
            }
            else if (movingleft)
            {
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, movementSpeed * 18);
            }
            else
            {
                transform.Translate(0, 0, movementSpeed);
            }
            
            
        }

    }

    void OnTriggerEnter (Collider col)
    { 
        //Ataque
        if (col.gameObject.tag == "Beam" && invincible == false)
        {
            jumpings.clip = daños;
            jumpings.Play();
            endofinvinsible = Mathf.Floor(Time.time) + invinsibletime;
            vidasmax--;
            invincible = true;
        }
    }

}
