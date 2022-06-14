using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //get player objct
        Player = GameObject.Find("Player");
        //set offset to position in scene
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //follow player
        transform.position = Player.transform.position + offset;
    }
}
