using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallPopUp : MonoBehaviour
{
    public Vector3 upPos;
    public GameObject Player;
    public float threshhold;
    public float distanze;
    public float upDowner;
    private MeshRenderer mr;
    public GameObject triggerr;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        upPos = transform.position;
        //downPos = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanze = Vector3.Distance(upPos, Player.transform.position);

        transform.position = new Vector3(transform.position.x, upDowner, transform.position.z);

        if (distanze < threshhold)
        {
            upDowner = Mathf.Lerp(upDowner, 0.3f, 12f * Time.deltaTime);
            mr.enabled = true;
            Instantiate(triggerr, transform.position, transform.rotation);
        } else
        {
            upDowner = Mathf.Lerp(upDowner, -20, 1f * Time.deltaTime);
        }
    }
}
