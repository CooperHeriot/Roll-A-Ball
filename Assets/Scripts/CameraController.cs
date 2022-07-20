using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private PlayerControl plya;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //get player objct
        Player = GameObject.Find("Player");
        //set offset to position in scene
        offset = transform.position - Player.transform.position;

        plya = Player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //follow player
        if (plya.resseting == false)
        {
            transform.position = Player.transform.position + offset;
        }
    }
}
