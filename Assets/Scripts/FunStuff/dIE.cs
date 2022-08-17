using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dIE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("die", 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void die()
    {
        Destroy(gameObject);
    }
}
