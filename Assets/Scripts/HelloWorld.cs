using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    //Cooper Heriot
    /*Cooper
     
    Heriot */
    // Start is called before the first frame update

    public int counter;

    public Text Textworld;
    void Start()
    {
        Debug.Log("Hello World");
        print("Hello worl");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter += Random.Range(1,999);
            DisplayCount();
        }
    }

    void DisplayCount()
    {
        Debug.Log("da counter is at " + counter + " boi");
        Textworld.text = "hacha pacha";
    }
}
