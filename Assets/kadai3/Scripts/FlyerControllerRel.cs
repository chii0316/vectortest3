using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerControllerRel : MonoBehaviour
{
    public float speed = 1.5f;
    public float rotspeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.LeftArrow) )
        {
            GetComponent<Rigidbody>().AddTorque( -transform.up * rotspeed );
        }
        if( Input.GetKey(KeyCode.RightArrow) )
        {
            GetComponent<Rigidbody>().AddTorque( transform.up * rotspeed );
        }
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
