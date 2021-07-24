using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fecharcanvas : MonoBehaviour
{

    public Canvas Canvasfala;
    private bool canvasOn = true;
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            //if canvas is visible you have to hide it
            if (canvasOn)
            {
                canvasOn = false;
                Canvasfala.enabled = false;
            }
           
        }
        
    }
}

