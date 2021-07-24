using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    
    public GoToScene goToScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonGoToScene(string scene)
    {
        goToScene.ChangeScene(scene);
        
    }

    
}
