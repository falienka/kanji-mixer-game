using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int numberSelected = 0;
    public List<KanjiItem> kanjis;
    public KanjiSlot[] kanjiSlots;

    public void AddItem(KanjiItem item)
    {
        if(!IsFull()) kanjis.Add(item);
        UpdateInventory();
    }

    public void RemoveItem(KanjiItem item)
    {
        if (kanjis.Remove(item)) UpdateInventory();
    }

    public bool IsFull()
    {
        return kanjis.Count>= kanjiSlots.Length;
    }

    public HashSet<KanjiItem> GetSelectedItems()
    {
        var selectedKanjis = new HashSet<KanjiItem>();
        foreach (KanjiSlot slot in kanjiSlots)
        {
            if (slot.isSelected)
            {
                selectedKanjis.Add(slot.Item);
            }
        }
        return selectedKanjis;
    }

    public void UnselectAll()
    {
        foreach (KanjiSlot slot in kanjiSlots)
        {
            if (slot.isSelected)
            {
                slot.UnselectKanji();
            }
        }
    }

    public void GiveKanji()
    {
        foreach (KanjiSlot slot in kanjiSlots)
        {
            if (slot.isHeld)
            {
                slot.DisableKanji();
                GameManager.Inst.heldItem = null;
            }
        }
    }

    public void DisableUsed()
    {
        foreach (KanjiSlot slot in kanjiSlots)
        {
            if (slot.isSelected)
            {
                slot.DisableKanji();
            }
        }
    }

    private void UpdateInventory()
    {
        int i = 0;
        for (; i < kanjis.Count && i<kanjiSlots.Length; i++)
        {
            kanjiSlots[i].Item = kanjis[i];
        }
        for (; i < kanjiSlots.Length; i++)
        {
            kanjiSlots[i].Item = null;
        }
    }
}
