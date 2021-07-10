using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public Image speaker;

    private int currentIndex;
    private Conversation currentConvo;

    private int counter = 0;

    public void StartConversation(Conversation conv){
      currentIndex = 0;
      currentConvo = conv;
      ReadNext();
    }

    public void ButtonReadNext()
    {
      counter++;
      if(counter == 1)
      {
        ReadNext();
      } else
      {
        StopAllCoroutines();
        ShowNextLine();
      }
    }

    public void ReadNext(){
      counter++;
      speaker.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();

      StopAllCoroutines();
      StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
    }

    private IEnumerator TypeText(string text){
      dialogue.text = "";
      foreach(char letter in text.ToCharArray())
      {
        dialogue.text += letter;
        yield return new WaitForSecondsRealtime(0.025f);
      }
      currentIndex++;
      counter = 0;
    }

    public void ShowNextLine()
    {
      if(currentIndex > currentConvo.GetLength())
      {
        counter = 0;
        return;
      }

      dialogue.text = currentConvo.GetLineByIndex(currentIndex).dialogue;
      speaker.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
      currentIndex++;
      counter = 0;
    }

}
