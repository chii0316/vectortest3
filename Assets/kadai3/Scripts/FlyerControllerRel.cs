using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerControllerRel : MonoBehaviour
{
    public bool isRecoveryMode;
    public float speed;
    public float pitchSpeed;
    public float yawSpeed;
    public float recoverySpeed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if( Input.GetKey(KeyCode.LeftArrow) )
        {
            rb.AddTorque( -transform.up * yawSpeed );
        }
        if( Input.GetKey(KeyCode.RightArrow) )
        {
            rb.AddTorque( transform.up * yawSpeed );
        }
        if( Input.GetKey(KeyCode.UpArrow) )
        {
            rb.AddTorque( transform.right * pitchSpeed );
        }
        if( Input.GetKey(KeyCode.DownArrow) )
        {
            rb.AddTorque( -transform.right * pitchSpeed );
        }

        if( isRecoveryMode )
        {
            Vector3 av = rb.angularVelocity;
            Vector3 localav =
  transform.InverseTransformDirection(GetComponent<Rigidbody>().angularVelocity);
  rb.AddTorque( -transform.right * localav.x * recoverySpeed );
  rb.AddTorque( -transform.up * localav.y * recoverySpeed );
  rb.AddTorque( -transform.forward * localav.z * recoverySpeed );

            Vector3 gv = Vector3.Cross(transform.up, Vector3.up);
            Vector3 localgv =
                transform.InverseTransformDirection(gv);
            rb.AddTorque(transform.forward * localgv.z * 0.1f);

            rb.AddTorque( gv * 0.01f );
        }

        rb.velocity = transform.forward * speed;
    }
}
