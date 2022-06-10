using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeaming : MonoBehaviour
{
    public GameObject beam;
    public GameObject player;
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
            GameObject clon = Instantiate(beam, new Vector3(0f, 0f, 0f), new Quaternion(player.transform.rotation.x + 5f, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w)) ;
            Destroy(clon, 3);
        }
        
    }
}
