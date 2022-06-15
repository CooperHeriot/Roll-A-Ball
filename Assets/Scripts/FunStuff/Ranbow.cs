using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranbow : MonoBehaviour
{
    public Text teckst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        teckst.color = Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
    }
}
