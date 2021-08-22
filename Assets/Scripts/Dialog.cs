using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float typingSpeed = 0.015f;
    public GameObject okButton;
    public DialogObject resetDialog;

    public Text npcNameText;
    public List<string> sentences;

    private int _index;

    void Update()
    {
        if(textDisplay.text == sentences[_index])
        {
            okButton.SetActive(true);
        }
    }

    public void StartDialog(DialogObject dialog)
    {
        textDisplay.text = "";
        npcNameText.text = dialog.npcName;
        sentences = new List<string>(dialog.dialogSentences);
        gameObject.SetActive(true);
        _index = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (var letter in sentences[_index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        okButton.SetActive(false);

        if(_index < sentences.Count - 1)
        {
            _index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            gameObject.SetActive(false);
        }
    }
}
