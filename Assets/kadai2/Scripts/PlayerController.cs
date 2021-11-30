using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject tama;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space) )
        {
            Vector3 p = gameObject.transform.position;
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            Vector3 e = enemy.transform.position;

            Vector3 v = e-p;
            tama.GetComponent<TamaMover>().velocity = v;
        }

        if( Input.GetKeyDown(KeyCode.R) )
        {
            SceneManager.LoadScene(0);
        }
    }
}
