using UnityEngine;
using TMPro;

public class GiveKanjiPopUp : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public void GiveKanjiPopUpText(KanjiItem heldKanji)
    {
        gameObject.SetActive(true);
        textDisplay.text = "Click on the person you want to give "+ heldKanji.kanjiName + " kanji to";
    }
}
