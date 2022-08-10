using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRaotate : MonoBehaviour
{
    //do not rotate
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
