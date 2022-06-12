using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public GameObject beam;
    public GameObject player;
    public GameObject bullet;
    public float rotation;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, rotation);
        time = Time.time;
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameObject clon = Instantiate(beam, this.gameObject.transform);
            clon.transform.eulerAngles = this.transform.eulerAngles + new Vector3 (90f, 0f, 90f);
            Destroy(clon, 3.6f);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
                for (float i = 0; i <= 360; i += 90)
                {
                    GameObject clonb = Instantiate(bullet, this.gameObject.transform);
                    clonb.transform.Rotate(0f, i, 0f);
                    Destroy(clonb, 3.6f);
                }
        }
    }
}
