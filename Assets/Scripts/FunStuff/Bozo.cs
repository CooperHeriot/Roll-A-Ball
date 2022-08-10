using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bozo : MonoBehaviour
{
    public GameObject target;
    public bool go;
    private Rigidbody rb;
    private float power;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (go == true)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            rb.AddForce(relativePos * power);
            power += 0.1f;
        }
    }
}
