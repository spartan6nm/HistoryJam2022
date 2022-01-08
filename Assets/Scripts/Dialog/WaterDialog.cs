using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDialog : Dialog
{
    private void Start()
    {
        StartCoroutine(Type());
    }

    public override IEnumerator Type()
    {
        for (int i = 0; i < dialogs[indexDialogs].sentences[indexSentences].ToCharArray().Length; i++)
        {
            if (i <= 1)
            {
                continueButton.interactable = false;
            }
            else if (i >= dialogs[indexDialogs].sentences[indexSentences].ToCharArray().Length - 1)
            {
                continueButton.interactable = true;
            }
            DialogText.text += dialogs[indexDialogs].sentences[indexSentences].ToCharArray()[i];
            yield return new WaitForSeconds(typingSpeed);


        }
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
                indexDialogs = 0;
                indexSentences = 0;
                Manager.water = true;
                Manager.Instance.MusicStop();
                EventBroker.CallPlaySound("23");
                Inventory.instance.Add(Manager.Instance.ceramic1);
                SceneManager.LoadScene(3);
            }
            else
            {

                NextDialog();
            }
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
