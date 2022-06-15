using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public float count;

    public GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        //get rigibody
        rb = GetComponent<Rigidbody>();
        count = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get inputs
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //set vector3
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //add force
        rb.AddForce(movement * speed);
        count = GameObject.FindGameObjectsWithTag("PickUp").Length;

        //wincondition

        if (count == 0)
        {
            WinText.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //pickup stuff
        if (other.gameObject.tag == ("PickUp")){
            //Pickupdate();
            Destroy(other.gameObject);
        }
    }

    //void Pickupdate()
    //{
    //    count = GameObject.FindGameObjectsWithTag("PickUp").Length;
    //}
}
