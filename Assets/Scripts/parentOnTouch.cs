using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentOnTouch : MonoBehaviour
{
    public GameObject model;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.transform.parent = model.transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
