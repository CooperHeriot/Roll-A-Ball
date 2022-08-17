using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class level4TextChanger : MonoBehaviour
{
    public float count;
    public TMP_Text textt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = FindObjectsOfType<dIE>().Length;

        if (count > 0)
        {
            textt.text = ("level 4: SIKE!!! You Thought!");
        }
    }
}
