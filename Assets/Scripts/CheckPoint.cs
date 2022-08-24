using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject rp;
    public GameObject one, two, tre, fur;
    public float numb;
    private bool done;
    public GameObject newTHing;
    // Start is called before the first frame update
    void Start()
    {
        rp = GameObject.Find("RespawnPoint");
        newTHing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (done == true)
        {
            one.transform.localPosition = new Vector3(numb, 0, 0);
            two.transform.localPosition = new Vector3(-numb, 0, 0);
            tre.transform.localPosition = new Vector3(0, 0, numb);
            fur.transform.localPosition = new Vector3(0, 0, -numb);
            numb = Mathf.Lerp(numb, 1, 1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            done = true;
            rp.transform.position = transform.position;
            newTHing.SetActive(true);
        }
    }
}
