using UnityEngine;

[System.Serializable]
public class DialogueLine
{
  public Speaker speaker1, speaker2;
  [TextArea]
  public string dialogue;
}
