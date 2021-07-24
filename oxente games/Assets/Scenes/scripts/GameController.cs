using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject canvacredito;
    
    public GameObject Canvaschave;
    public static GameController instance;
    //public Image whiteFade;

    



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //whiteFade.canvasRenderer.SetAlpha(1.0f);
        fadeIn();

    }

    

    public void canvaschave1()
    {
        Canvaschave.SetActive(true);


    }

    public void canvacredito1()
    {
        canvacredito.SetActive(true);
    }

    public void OnMouseDown()
    {
        canvacredito.SetActive(false);
    }

   



    void fadeIn()
    {
        //whiteFade.CrossFadeAlpha(0, 2, false);
       // Destroy(whiteFade, 2f);


    }

    


  

    


}


