using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingController : MonoBehaviour
{
    public GameObject tamaPrefab;
    bool isCoolingDown;

    // Start is called before the first frame update
    void Start()
    {
        isCoolingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( !isCoolingDown )
        {
            if( Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) )
            {
                Vector3 d = GetComponent<Rigidbody>().velocity;
                d.Normalize();
                Vector3 p = transform.position + d * 1.5f;
                GameObject tama = Instantiate(tamaPrefab, p , Quaternion.identity);

                Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                tama.GetComponent<Rigidbody>().velocity = v * 3;
                StartCoroutine( StartCoolDown() );
            }
        }
    }

    IEnumerator StartCoolDown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(2.0f);
        isCoolingDown = false;
    }
}
