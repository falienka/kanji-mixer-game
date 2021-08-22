using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogObject : ScriptableObject
{
    public string npcName;
    [TextArea]
    public List<string> dialogSentences;
}
