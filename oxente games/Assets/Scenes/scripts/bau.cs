using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bau : MonoBehaviour
{


    public Animator anim;
    public GameObject key;
    public BoxCollider2D bc;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            anim.enabled = true;    
            key.SetActive(true);
            Destroy(bc);
        }
    }
}
