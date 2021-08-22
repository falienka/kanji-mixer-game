using Optional;
using System.Collections.Generic;
using UnityEngine;

public class MixKanjiButtonController : MonoBehaviour
{
    public List<KanjiMixingRecipe> kanjiMixes;
    private Inventory _inventory;

    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public Option<KanjiMixingRecipe> FindMix(HashSet<KanjiItem> selectedKanji)
    { 
        foreach (var item in kanjiMixes)
        {
            if (item.Validate(_inventory.GetSelectedItems()))
                return item.Some();
        }
        return Option.None<KanjiMixingRecipe>();
    }

    public void MixKanji()
    {
        var selectedItems = _inventory.GetSelectedItems();
        FindMix(selectedItems).Match(kanjiMix => {
            _inventory.AddItem(kanjiMix.outKanjiItem);
            kanjiMixes.Remove(kanjiMix);
            _inventory.DisableUsed();
        }, () => _inventory.UnselectAll());
        
    }

}
