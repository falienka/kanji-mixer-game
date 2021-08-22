using UnityEngine;

[CreateAssetMenu]
public class KanjiItem : ScriptableObject
{
    public string kanjiName;
    public Sprite kanjiIcon;
    public Sprite kanjiCharacter;
    public string kanjiTranslation;
    [TextArea]
    public string kanjiReading;
}
