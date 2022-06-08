using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leginhibitor : MonoBehaviour
{
    public GameObject leg1;
    public GameObject leg2;

    public LegBehav leggn1;
    public LegBehav leggn2;

    private float numbas = 1;
    // Start is called before the first frame update
    void Start()
    {
        leggn1 = leg1.GetComponent<LegBehav>();
        leggn2 = leg2.GetComponent<LegBehav>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leggn1.step == true || leggn1.step2 == true)
        {
            leggn2.allowef = false;
        }
        else
        {
            numbas -= 1f * Time.deltaTime;
            if (numbas < 0)
            {
                leggn2.allowef = true;
                numbas = 1;
            }
            
        }

        if (leggn2.step == true || leggn2.step2 == true)
        {
            leggn1.allowef = false;
        }
        else
        {
            numbas -= 1f * Time.deltaTime;
            if (numbas < 0)
            {
                leggn1.allowef = true;
                numbas = 1;
            }
        }
    }
}
