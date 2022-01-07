using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialog : Dialog
{
    private void Start()
    {
        StartCoroutine(Type());
    }

    public override void NextSentence()
    {
        EventBroker.CallPlaySound("dialogue_advance");
        if (indexSentences < dialogs[indexDialogs].sentences.Length - 1)
        {
            StopCoroutine(Type());
            indexSentences++;
            DialogText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            if (indexDialogs >= dialogs.Length - 1)
            {
                //TODO this dialog is over in whole
                PlayerPrefs.SetInt("Played", 1);
            }
            NextDialog();
        }
    }

    public override void NextDialog()
    {
        StopCoroutine(Type());
        indexSentences = 0;
        indexDialogs++;
        DialogText.text = "";
        StartCoroutine(Type());
    }
}
