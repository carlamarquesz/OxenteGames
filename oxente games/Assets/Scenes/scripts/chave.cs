using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chave : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    private void Start()
    {
        
       
    }


    void pegarchave()
    {
        Destroy(gameObject);
        GameController.instance.canvaschave1();
        GameData.chave = true;
    }
}
