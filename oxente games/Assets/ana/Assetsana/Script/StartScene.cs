using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public DialogueManager DialogueManager; 
    public Conversation currentConvo;
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.StartConversation(currentConvo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
