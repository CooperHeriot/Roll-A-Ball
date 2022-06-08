using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attraction : MonoBehaviour
{
    public GameObject target;

   // public Quaternion wah;
   // private Vector3 jah;

    public float power = 1;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // wah = Quaternion.LookRotation(transform.position - target.transform.position);

        //jah = new Vector3(wah.x, wah.y, wah.z);

        //rb.AddForce(jah * 10);

        Vector3 relativePos = target.transform.position - transform.position;
        rb.AddForce(relativePos * power);

        // rb.MovePosition(target.transform.position * power);
        // rb.
    }
}
