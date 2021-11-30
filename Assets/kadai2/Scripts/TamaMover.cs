using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaMover : MonoBehaviour
{
    public Vector3 velocity;
    Vector3 orginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        orginalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        if( Mathf.Abs(transform.position.x) > 20.0f || Mathf.Abs(transform.position.z) > 20.0f )
        {
            transform.position = orginalPosition;
            velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Hit!");
        if( c.gameObject.CompareTag("Enemy") )
        {
            c.gameObject.SetActive(false);
        }
    }
}
