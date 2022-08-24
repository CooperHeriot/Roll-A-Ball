using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pusshOntouch : MonoBehaviour
{
    public Vector3 boostDirection = new Vector3(0, 1, 0);
    public float power = 250;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(boostDirection * power);
        }
    }
}
