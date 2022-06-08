using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
    public GameObject Part1;
    public GameObject Part2;

    private float x;
    private float y;
    private float z;

    public GameObject Model;

    public float dista;
    public float thiccness = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Part1.transform.position.x + Part2.transform.position.x;
        y = Part1.transform.position.y + Part2.transform.position.y;
        z = Part1.transform.position.z + Part2.transform.position.z;

        transform.position = new Vector3((x / 2), (y / 2), (z / 2));

        Model.transform.rotation = Quaternion.LookRotation(transform.position - Part1.transform.position);

        dista = Vector3.Distance(Part1.transform.position, Part2.transform.position);

        Model.transform.localScale = new Vector3(thiccness, thiccness, dista * 10);
    }
}
