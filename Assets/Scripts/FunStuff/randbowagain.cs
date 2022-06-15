using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randbowagain : MonoBehaviour
{
    public MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
    }
}
