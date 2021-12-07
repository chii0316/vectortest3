using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool isChasing;
    public GameObject tama;
    // Start is called before the first frame update
    void Start()
    {
        isChasing = true;
        tama.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = gameObject.transform.position;
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 v = Vector3.zero;
        if( enemy != null )
        {
            Vector3 e = enemy.transform.position;
            Vector3 speed = enemy.GetComponent<Rigidbody>().velocity;
            // 目標地点を「敵が少し移動した先」にしたい
            v = (e+speed*0.9f)-p;
            // その場所に向く
            if( isChasing )
                gameObject.transform.forward = v;
        }

        if( Input.GetKeyDown(KeyCode.Space) )
        {
            tama.transform.position = gameObject.transform.position;
            tama.GetComponent<TamaMover>().velocity = v;
            isChasing = false;
            StartCoroutine(ResetChaseMode());
        }

        if( Input.GetKeyDown(KeyCode.R) )
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator ResetChaseMode()
    {
        yield return new WaitForSeconds(2.0f);
        isChasing = true;
    }
}
