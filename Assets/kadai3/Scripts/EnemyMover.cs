using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
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
            GetComponent<Rigidbody>().AddTorque( -transform.up );
        }
        if( Input.GetKey(KeyCode.RightArrow) )
        {
            GetComponent<Rigidbody>().AddTorque( transform.up );
        }
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
