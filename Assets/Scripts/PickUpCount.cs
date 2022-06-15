using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCount : MonoBehaviour
{
    public float count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //count = FindObjectOfType <>
        count = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }
}
