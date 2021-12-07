using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
