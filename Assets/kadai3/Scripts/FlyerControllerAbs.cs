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
        if( Input.GetKey(KeyCode.RightArrow) )
        {
            GetComponent<Rigidbody>().AddForce( Vector3.right );
        }
    }
}
