using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{
    public Text text;
    public Color newColorIn, newColorOut;

    public void ChangeColorIn(){
      text.color = newColorIn;
    }

    public void ChangeColorOut(){
      text.color = newColorOut;
    }
}
