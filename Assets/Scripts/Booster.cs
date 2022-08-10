using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Vector3 boostDirection = new Vector3(0, 1, 0);
    public float power = 250;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.attachedRigidbody.AddForce(boostDirection * power);
        }
    }
}
