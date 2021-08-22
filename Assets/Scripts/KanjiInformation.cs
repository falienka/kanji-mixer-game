using UnityEngine;
using UnityEngine.UI;

public class KanjiInformation : MonoBehaviour
{
    public Image kanjiCharacter;
    public Text translationText;
    public Text readingText;

    public void ShowInformation(KanjiItem kanjiItem)
    {
        kanjiCharacter.sprite = kanjiItem.kanjiCharacter;
        translationText.text = "Translation:\n" + kanjiItem.kanjiTranslation;
        readingText.text = "Reading:\n" + kanjiItem.kanjiReading;
        gameObject.SetActive(true);
    }

    public void HideInformation()
    {
        gameObject.SetActive(false);
    }
}
