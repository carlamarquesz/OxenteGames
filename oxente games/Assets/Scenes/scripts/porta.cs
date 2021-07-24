using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{

    private Animator anim;
    
    public static bool entrandoporta;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "player" && GameData.chave == true)
        {

            //if(GameData.GameController == true)
            //{
                    anim.enabled = true;
                    entrandoporta = true;
                
            //}
            
        }

    }
}
