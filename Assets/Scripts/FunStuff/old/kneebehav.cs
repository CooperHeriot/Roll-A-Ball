using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kneebehav : MonoBehaviour
{
    public GameObject foot;
    public GameObject Joint;

    public GameObject kneeChap;
    private float leglength;
    public float legstuf;
    private float posx, posy, posz;
    // Start is called before the first frame update
    void Start()
    {
        leglength = Vector3.Distance(foot.transform.position, Joint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        posx = ((foot.transform.position.x + Joint.transform.position.x) / 2);
        posy = ((foot.transform.position.y + Joint.transform.position.y) / 2);
        posz = ((foot.transform.position.z + Joint.transform.position.z) / 2);

        transform.position = new Vector3(posx, posy, posz);

        legstuf = Vector3.Distance(foot.transform.position, Joint.transform.position);

        if (legstuf < leglength)
        {
            kneeChap.transform.localPosition = new Vector3(transform.position.x + ((leglength - legstuf) * -1), transform.position.y, transform.position.z);
        }
    }
}
