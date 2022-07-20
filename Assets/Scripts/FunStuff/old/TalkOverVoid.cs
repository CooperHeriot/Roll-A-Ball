using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOverVoid : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        if (transform.position.y < 0)
        {
            Text.SetActive(true);
        }
    }
}
