using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerControllerAbs : MonoBehaviour
{
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.A) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.left );
        }
        if( Input.GetKey(KeyCode.D) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.right );
        }
        if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce( Vector3.forward );
        }
        if(Input.GetKey(KeyCode.S))
        { 
            GetComponent<Rigidbody>().AddForce( Vector3.back );
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce( Vector3.up );
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce( Vector3.down );
        }
    }
}
