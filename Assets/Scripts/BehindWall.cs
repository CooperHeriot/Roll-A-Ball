using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindWall : MonoBehaviour
{
    public GameObject Icon;
    public Material mat;
    private Vector2 fgfgf;

    public Camera TheCam;
    private GameObject mainCam;
    private GameObject playe;
    private Quaternion Aim;
    public GameObject RaycastBox;
    //private Vector3 thth;

    public MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mat = Icon.GetComponent<Renderer>().material;

        mainCam = GameObject.Find("Main Camera");
        playe = GameObject.Find("Player");

        TheCam.transform.parent = mainCam.transform;
        TheCam.transform.position = mainCam.transform.position;
        TheCam.transform.rotation = mainCam.transform.rotation;
        TheCam.transform.localScale = mainCam.transform.localScale;

        Icon.transform.parent = null;
        RaycastBox.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //scrolling texture
        RaycastBox.transform.position = mainCam.transform.position;
        Icon.transform.position = playe.transform.position;
        //Icon.transform.rotation = playe.transform.rotation;

        fgfgf = new Vector2(fgfgf.x + 0.1f * Time.deltaTime, 0);

        mat.SetTextureOffset("_MainTex", fgfgf);


        //checking if player is visible
        RaycastBox.transform.rotation = Quaternion.LookRotation(playe.transform.position - RaycastBox.transform.position);
        //thth = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        RaycastHit Hit;
        if (Physics.Raycast(mainCam.transform.position, RaycastBox.transform.forward, out Hit))
        {
            if (Hit.collider.gameObject == playe)
            {
                Icon.SetActive(false);
            } else
            {
                Icon.SetActive(true);
            }
        }
       // Debug.DrawRay(mainCam.transform.position, thth);
    }

    //private void OnBecameInvisible()
    //{
        //Icon.GetComponent<MeshRenderer>().enabled = true;
        //mr.enabled = true;
    //    Icon.SetActive(true);
    //}

    //private void OnBecameVisible()
    //{
        //Icon.GetComponent<MeshRenderer>().enabled = false;
        //mr.enabled = false;
    //    Icon.SetActive(false);
    //}
}
