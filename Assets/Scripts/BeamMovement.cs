using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    public GameObject beam;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject beamnuevo;

        if (Input.GetKeyDown(KeyCode.N))
        {
            beamnuevo = Instantiate(beam);
            beamnuevo.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, rotation);
        }


    }

}
