using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public float count;

    GameObject ressetPoint;
    public bool resseting = false;
    Color origColor;
    private TrailRenderer aaaa;

    public GameObject WinText;
    public Image Imag;
    public TMP_Text Bloks;
    private float smount;
    // Start is called before the first frame update
    void Start()
    {
        //get rigibody
        rb = GetComponent<Rigidbody>();
        //check how many pickups there are
        count = GameObject.FindGameObjectsWithTag("PickUp").Length;
        smount = count;
        CheckPickup();
        WinText.SetActive(false);

        ressetPoint = GameObject.Find("RespawnPoint");
        origColor = GetComponent<Renderer>().material.color;
        aaaa = GetComponent<TrailRenderer>();
        aaaa.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count == 0)
        {
            return;
        }
        if (resseting)
            return;

        //get inputs
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //set vector3
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //add force
        rb.AddForce(movement * speed);
        CheckPickup();
    }

    void OnTriggerEnter(Collider other)
    {
        //pickup stuff
        if (other.gameObject.tag == ("PickUp")){
            //Pickupdate();
            Destroy(other.gameObject);
        }
        CheckPickup();

        //reset if hurt
        if (other.gameObject.tag == ("Respawn"))
        {
            Invoke("Resetinng", 1);
            GetComponent<Renderer>().material.color = Color.black;
            resseting = true;
            aaaa.enabled = true;
        }
    }

    void CheckPickup()
    {

        count = GameObject.FindGameObjectsWithTag("PickUp").Length;

        //fill the diaomnd
        Imag.fillAmount = 1 - (count / smount);

        //counter
        Bloks.text = count.ToString() + "/" + smount.ToString();


        //set win text to true if all things collected
        if (count == 0)
        {
            WinText.SetActive(true);
        }
    }
    //reset the game

    public void Resetinng()
    {
        transform.position = ressetPoint.transform.position;
        resseting = false;
        GetComponent<Renderer>().material.color = origColor;
        rb.velocity = Vector3.zero;
        aaaa.enabled = false;
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
