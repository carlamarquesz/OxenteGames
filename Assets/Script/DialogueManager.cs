using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public Image speaker1, speaker2;

    private int currentIndex;
    private Conversation currentConvo;

    public void StartConversation(Conversation conv){
      currentIndex = 0;
      currentConvo = conv;
      ReadNext();
    }

    public void ReadNext(){
      speaker1.sprite = currentConvo.GetLineByIndex(currentIndex).speaker1.GetSprite();
      speaker2.sprite = currentConvo.GetLineByIndex(currentIndex).speaker2.GetSprite();

      StopAllCoroutines();
      StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
      currentIndex++;
    }

    private IEnumerator TypeText(string text){
      dialogue.text = "";
      foreach(char letter in text.ToCharArray())
      {
        dialogue.text += letter;
        yield return new WaitForSecondsRealtime(0.025f);
      }
    }

}
