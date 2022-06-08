using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegBehav : MonoBehaviour
{
    public GameObject foot;
    public GameObject footref;
    public float speed;
    public float stepheight;
    public bool allowef;
    public bool step;
    public bool step2;
    public float maxDist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(foot.transform.position, footref.transform.position) > maxDist && allowef == true)
        {
            step = true;
        }

        if (step == true)
        {
            foot.transform.position = Vector3.MoveTowards(foot.transform.position, new Vector3(footref.transform.position.x, footref.transform.position.y + stepheight, footref.transform.position.z), speed);
            //foot.transform.rotation = foot.transform.position - footref.transform.position;
        }

        if (foot.transform.position == new Vector3(footref.transform.position.x, footref.transform.position.y + stepheight, footref.transform.position.z))
        {
            step = false;
            step2 = true;
        }

        if (step2 == true)
        {
            foot.transform.position = Vector3.MoveTowards(foot.transform.position, footref.transform.position, speed);
        }

        if (foot.transform.position == footref.transform.position)
        {
            step2 = false;
        }
    }
}
