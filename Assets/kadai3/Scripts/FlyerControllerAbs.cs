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
        if( Input.GetKey(KeyCode.LeftArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.left );
        }
        if( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.left, ForceMode.Impulse );
        }
        if( Input.GetKey(KeyCode.RightArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.right );
        }
        if( Input.GetKeyDown(KeyCode.RightArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.right, ForceMode.Impulse );
        }
        if( Input.GetKey(KeyCode.UpArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.forward );
        }
        if( Input.GetKey(KeyCode.DownArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.back );
        }
    }
}
