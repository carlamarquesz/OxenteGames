using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class luzlanterna : MonoBehaviour
{
    public Light2D luz;
    // Start is called before the first frame update
    void Start()
    {
        luz.GetComponent<Light2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (luz.GetComponent<Light2D>().enabled == true)
            {
                luz.GetComponent<Light2D>().enabled = false;

            }
            else
            {
                luz.GetComponent<Light2D>().enabled = true;
            }
        }
    }
}
