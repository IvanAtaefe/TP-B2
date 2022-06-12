using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public GameObject beam;
    public GameObject player;
    public GameObject bullet;
    Quaternion playerrotation;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameObject clon = Instantiate(beam, new Vector3(0f, 0f, 12f), new Quaternion(90f, 90f, 90f, 90f));
            Destroy(clon, 3.6f);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject clonb = Instantiate(bullet, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            //GameObject clonb2 = Instantiate(bullet, new Vector3(0f, 0f, 0f), new Quaternion(90f, 90f, 90f, 90f));
            GameObject clonb3 = Instantiate(bullet, new Vector3(0f, 0f, 0f), new Quaternion(180f, 180f, 180f, 180f));
            //GameObject clonb4 = Instantiate(bullet, new Vector3(0f, 0f, 0f), new Quaternion(270f, 270f, 270f, 270f));
            //Destroy(clonb, 3.6f);
            //Destroy(clonb2, 3.6f);
            //Destroy(clonb3, 3.6f);
            //Destroy(clonb4, 3.6f);
        }
    }
}
