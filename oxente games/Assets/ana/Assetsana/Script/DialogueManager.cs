using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    // public fecharcanvas FecharCanvas;
    public GoToScene goToScene;
    public TextMeshProUGUI dialogue;
    public Image speaker;

    private int currentIndex;
    private Conversation currentConvo;
    private Animator anim;

    private int counter = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //
    // public void Buttonfecharcanvas()
    // {
    //     Destroy(FecharCanvas);
    // }

    public void StartConversation(Conversation conv)
    {
        anim.SetBool("isOpen", true);
        currentIndex = 0;
        currentConvo = conv;
        ReadNext();
        Debug.Log("Teste");

    }



    public void ButtonGoToScene(string scene)
    {
        if (currentIndex > currentConvo.GetLength())
        {
            goToScene.ChangeScene(scene);
        }
        else
        {
            ButtonReadNext();
        }
    }

    public void ButtonReadNext()
    {
        counter++;
        if (counter == 1)
        {
            ReadNext();
        }
        else
        {
            StopAllCoroutines();
            ShowNextLine();
        }
    }

    public void ReadNext()
    {
        counter++;
        speaker.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();

        StopAllCoroutines();
        StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));

    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSecondsRealtime(0.025f);
        }
        currentIndex++;
        counter = 0;

    }

    public void ShowNextLine()
    {
        if (currentIndex > currentConvo.GetLength())
        {
            anim.SetBool("isOpen", false);
            counter = 0;
            return;
        }

        dialogue.text = currentConvo.GetLineByIndex(currentIndex).dialogue;
        speaker.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;
        counter = 0;
    }

}
