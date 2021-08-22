using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KanjiMixingRecipe : ScriptableObject
{
    public List<KanjiItem> inKanjiItems;
    public KanjiItem outKanjiItem;

    public bool Validate(HashSet<KanjiItem> kanjiCheck)
    {
        var kanjiHashSet = new HashSet<KanjiItem>(inKanjiItems);
        return kanjiHashSet.SetEquals(kanjiCheck);
    }
}
