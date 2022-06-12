using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeaming : MonoBehaviour
{
    public GameObject beam;
    public GameObject player;
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
        
    }
}
