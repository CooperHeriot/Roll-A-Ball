using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    //movement
    private Rigidbody rb;
    public float speed;

    public float count;

    //reset the gameobject when dead
    GameObject ressetPoint;
    public bool resseting = false;
    Color origColor;
    private TrailRenderer aaaa;

    //pickup count
    public GameObject WinText;
    public Image Imag;
    public TMP_Text Bloks;
    private float smount;

    //Controllers
    GameController gameController;
    Timer timer;

    //DeathScreech
    private AudioSource screm;

    //sound controller
    SoundController soundController;

    //crosshair
    public GameObject shadow;
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
        soundController = FindObjectOfType<SoundController>();

        ressetPoint = GameObject.Find("RespawnPoint");
        origColor = GetComponent<Renderer>().material.color;
        aaaa = GetComponent<TrailRenderer>();
        aaaa.enabled = false;

        screm = GetComponent<AudioSource>();

        gameController = FindObjectOfType<GameController>();
        timer = FindObjectOfType<Timer>();
        if (gameController.gameType == GameType.SpeedRun)
            StartCoroutine(timer.StartCountdown());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameController.gameType == GameType.SpeedRun && !timer.IsTiming())
            return;

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

        //shadow
        RaycastHit Hit;
        if (Physics.Raycast (transform.position, Vector3.down, out Hit, 100, ~6))
        {
            //if (onfloor == false) { }
            shadow.SetActive(true);
            shadow.transform.position = Hit.point;
            //shadow.transform.position = new Vector3(transform.position.x, Hit.point.y, transform.position.z);
        } else
        {
            shadow.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //pickup stuff
        if (other.gameObject.tag == ("PickUp")){
            //Pickupdate();
            other.GetComponent<Particles>().CreateParticles();
            soundController.PlayPickupSound();
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

            screm.pitch = Random.Range(0.8f, 1.4f);
            screm.Play();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Wall"))
        {
            //Pickupdate();
            soundController.PlayCollisionSound(other.gameObject);
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
            shadow.SetActive(false);
            WinText.SetActive(true);
            if (gameController.gameType == GameType.SpeedRun)
                timer.StopTimer();
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

        //screm.Stop();
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void WinGame()
    {
        WinText.SetActive(true);

        soundController.PlayWinSound();
        if (gameController.gameType == GameType.SpeedRun)
            timer.StopTimer();
    }

   // private void OnBecameInvisible()
    //{
    //    print("Invis");
    //    //Icon.GetComponent<MeshRenderer>().enabled = true;
        //mr.enabled = true;
    //    Icon.SetActive(true);
    //}

   // private void OnBecameVisible()
    //{
    //    print("vis");
        //Icon.GetComponent<MeshRenderer>().enabled = false;
        //mr.enabled = false;
    //    Icon.SetActive(false);
    //}
}
