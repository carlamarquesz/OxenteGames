using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Conversation currentConvo;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("falainic")==0){
            dialogueManager.StartConversation(currentConvo);
            PlayerPrefs.SetInt("falainic",1);
        }
    }

}
