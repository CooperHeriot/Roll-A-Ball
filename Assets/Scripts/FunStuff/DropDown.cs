using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    public GameObject Menu;
    private bool toggle = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle == true)
        {
            Menu.SetActive(true);
        } else
        {
            Menu.SetActive(false);
        }
    }

    public void toggl()
    {
        toggle = !toggle;
    }
}
