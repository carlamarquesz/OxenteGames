using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class janela : MonoBehaviour
{

    // Start is called before the first frame update
    public Light2D luz;


    void Start()
    {
        StartCoroutine(trovejo());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator trovejo()
    {
        yield return new WaitForSeconds(0.1f);
        luz.intensity = 0.5f;
        yield return new WaitForSeconds(0.1f);
        luz.intensity = 1f;
        yield return new WaitForSeconds(0.1f);
        luz.intensity = 0.5f;
        yield return new WaitForSeconds(0.1f);
        luz.intensity = 1f;
        yield return new WaitForSeconds(5f);
        StartCoroutine(trovejo());
    }

}
