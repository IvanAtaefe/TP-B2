using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
   
    public AudioSource action;
    public AudioClip beams;
    public AudioClip bullets;
    public GameObject beam;
    public GameObject player;
    public GameObject bullet;
    public float rotation;
    public float destroybullet;
    float secondpassed = 5;
    bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        secondpassed = Mathf.Floor(Time.time + 5);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, rotation);

        int r = Random.Range(0, 100);
        if (Mathf.Floor(Time.time) == secondpassed) {

            secondpassed++;
            if (r <= 10)
            {
                action.clip = beams;
                action.Play();
                attacking = true;
                GameObject clon = Instantiate(beam, this.gameObject.transform);
                clon.transform.eulerAngles = this.transform.eulerAngles + new Vector3(90f, 0f, 90f);
                Destroy(clon, destroybullet);
            }
            else if (r >= 90)
            {
                rotation *= -1;
            }
            else if (r > 40 && r < 55)
            {

            }
            else
            {
                float y = Random.Range(0f, 3f);
                disparar(y);
            }

        }
       
    }
    void disparar( float r)
    {

        for (float i = 0; i <= 360; i += 90)
        {
            action.clip = bullets;
            action.Play();
            GameObject clonb = Instantiate(bullet, new Vector3(transform.position.x, r, transform.position.z), this.gameObject.transform.rotation, this.gameObject.transform);
            clonb.transform.Rotate(0f, i, 0f);
            Destroy(clonb, 7.2f);
        }
    }
}
